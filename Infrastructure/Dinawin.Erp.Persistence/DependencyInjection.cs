using Dinawin.Erp.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dinawin.Erp.Persistence;

/// <summary>
/// تزریق وابستگی‌های لایه Persistence
/// Persistence layer dependency injection
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// افزودن سرویس‌های لایه Persistence
    /// Add persistence layer services
    /// </summary>
    /// <param name="services">مجموعه سرویس‌ها</param>
    /// <param name="configuration">پیکربندی</param>
    /// <returns>مجموعه سرویس‌ها</returns>
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // افزودن DbContext
        // Add DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });
        });

        // ثبت IApplicationDbContext
        // Register IApplicationDbContext
        services.AddScoped<IApplicationDbContext>(provider => 
            provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
