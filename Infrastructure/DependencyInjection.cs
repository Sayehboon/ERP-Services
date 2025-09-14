using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dinawin.Erp.Infrastructure;

/// <summary>
/// تزریق وابستگی‌های لایه Infrastructure
/// Infrastructure layer dependency injection
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// افزودن سرویس‌های لایه Infrastructure
    /// Add infrastructure layer services
    /// </summary>
    /// <param name="services">مجموعه سرویس‌ها</param>
    /// <param name="configuration">پیکربندی</param>
    /// <returns>مجموعه سرویس‌ها</returns>
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // افزودن سرویس‌های Infrastructure (Email, SMS, File Storage, etc.)
        // Add Infrastructure services (Email, SMS, File Storage, etc.)
        
        return services;
    }
}
