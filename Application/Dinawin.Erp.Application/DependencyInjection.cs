using Dinawin.Erp.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dinawin.Erp.Application;

/// <summary>
/// تزریق وابستگی‌های لایه Application
/// Application layer dependency injection
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// افزودن سرویس‌های لایه Application
    /// Add application layer services
    /// </summary>
    /// <param name="services">مجموعه سرویس‌ها</param>
    /// <returns>مجموعه سرویس‌ها</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        // افزودن MediatR
        // Add MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        // افزودن AutoMapper
        // Add AutoMapper
        services.AddAutoMapper(assembly);

        // افزودن FluentValidation
        // Add FluentValidation
        services.AddValidatorsFromAssembly(assembly);

        // افزودن Pipeline Behaviors
        // Add Pipeline Behaviors
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        return services;
    }
}
