using Dinawin.Erp.Application;
using Dinawin.Erp.Infrastructure;
using Dinawin.Erp.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Dinawin ERP API",
        Version = "v1",
        Description = "سیستم جامع مدیریت منابع سازمانی دیناوین با معماری DDD و الگوی CQRS",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Dinawin ERP Team",
            Email = "support@dinawin.com"
        }
    });
    
    // Configure custom schema ID generator to avoid conflicts with same class names in different namespaces
    options.CustomSchemaIds(type =>
    {
        // Use full namespace to create unique schema IDs
        return type.FullName?.Replace("+", ".") ?? type.Name;
    });
    
    // Include XML comments for better documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

// Add application layers
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);

// Add sample data service
builder.Services.AddScoped<Dinawin.Erp.Application.Services.SampleDataService>();

// Add CORS - Read from configuration
builder.Services.AddCors(options =>
{
    var corsSettings = builder.Configuration.GetSection("Cors");
    var enableCors = corsSettings.GetValue<bool>("Enabled", true);
    var allowedOrigins = corsSettings.GetSection("AllowedOrigins").Get<string[]>() ?? new string[0];
    var allowAnyOrigin = corsSettings.GetValue<bool>("AllowAnyOrigin", false);
    var allowCredentials = corsSettings.GetValue<bool>("AllowCredentials", true);

    if (enableCors)
    {
        options.AddPolicy("AllowFrontend", policy =>
        {
            if (allowAnyOrigin)
            {
                policy.AllowAnyOrigin();
            }
            else if (allowedOrigins.Length > 0)
            {
                policy.WithOrigins(allowedOrigins);
            }
            else
            {
                // Fallback to default origins based on environment
                if (builder.Environment.IsDevelopment())
                {
                    policy.WithOrigins(
                        "http://localhost:3000", 
                        "http://localhost:5173", 
                        "http://localhost:8080",
                        "https://localhost:3000",
                        "https://localhost:5173");
                }
                else
                {
                    // Production fallback - no origins allowed
                    return;
                }
            }

            policy.AllowAnyHeader()
                  .AllowAnyMethod();

            if (allowCredentials && !allowAnyOrigin)
            {
                policy.AllowCredentials();
            }
        });
    }
});

// Add health checks
//builder.Services.AddHealthChecks()
//    .AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!,  "Database");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Dinawin ERP API v1");
        options.RoutePrefix = "swagger";
        options.DocumentTitle = "Dinawin ERP API Documentation";
        options.DefaultModelsExpandDepth(-1);
        options.DefaultModelExpandDepth(0);
        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        options.DisplayRequestDuration();
        options.EnableFilter();
        options.EnableDeepLinking();
        options.EnableTryItOutByDefault();
        options.ShowExtensions();
        options.ShowCommonExtensions();
        options.InjectStylesheet("/swagger-ui/custom.css");
        options.InjectJavascript("/swagger-ui/custom.js");
    });
}
else if (app.Environment.IsProduction())
{
    // Production environment - Swagger disabled for security
    // Only enable if explicitly configured in appsettings.Production.json
    var enableSwagger = app.Configuration.GetValue<bool>("ApplicationSettings:EnableSwagger", false);
    if (enableSwagger)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Dinawin ERP API v1");
            options.RoutePrefix = "swagger";
            options.DocumentTitle = "Dinawin ERP API Documentation";
            options.DefaultModelsExpandDepth(-1);
            options.DefaultModelExpandDepth(0);
            options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        });
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.MapHealthChecks("/health");

// Apply EF Core migrations on startup to ensure database schema is up to date
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

app.Run();
