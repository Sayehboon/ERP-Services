using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Dinawin.Erp.Application.Common.Behaviors;

/// <summary>
/// رفتار لاگ‌گیری برای CQRS
/// Logging behavior for CQRS
/// </summary>
/// <typeparam name="TRequest">نوع درخواست</typeparam>
/// <typeparam name="TResponse">نوع پاسخ</typeparam>
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    /// <summary>
    /// سازنده رفتار لاگ‌گیری
    /// Logging behavior constructor
    /// </summary>
    /// <param name="logger">لاگر</param>
    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// اجرای رفتار لاگ‌گیری
    /// Execute logging behavior
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="next">عمل بعدی</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>پاسخ</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var stopwatch = Stopwatch.StartNew();

        _logger.LogInformation("دریافت درخواست: {RequestName} {@Request}", requestName, request);

        try
        {
            var response = await next();
            stopwatch.Stop();

            _logger.LogInformation("تکمیل درخواست: {RequestName} در {ElapsedMilliseconds}ms", 
                requestName, stopwatch.ElapsedMilliseconds);

            return response;
        }
        catch (Exception ex)
        {
            stopwatch.Stop();

            _logger.LogError(ex, "خطا در پردازش درخواست: {RequestName} در {ElapsedMilliseconds}ms", 
                requestName, stopwatch.ElapsedMilliseconds);

            throw;
        }
    }
}
