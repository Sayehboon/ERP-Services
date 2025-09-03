using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Dinawin.Erp.Application.Common.Behaviors;

/// <summary>
/// رفتار نظارت بر عملکرد برای CQRS
/// Performance monitoring behavior for CQRS
/// </summary>
/// <typeparam name="TRequest">نوع درخواست</typeparam>
/// <typeparam name="TResponse">نوع پاسخ</typeparam>
public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;
    private const int LongRunningRequestThreshold = 500; // milliseconds

    /// <summary>
    /// سازنده رفتار نظارت بر عملکرد
    /// Performance behavior constructor
    /// </summary>
    /// <param name="logger">لاگر</param>
    public PerformanceBehavior(ILogger<PerformanceBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// اجرای رفتار نظارت بر عملکرد
    /// Execute performance monitoring behavior
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="next">عمل بعدی</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>پاسخ</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();

        var response = await next();

        stopwatch.Stop();

        var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

        if (elapsedMilliseconds > LongRunningRequestThreshold)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogWarning("هشدار عملکرد: درخواست {RequestName} در {ElapsedMilliseconds}ms اجرا شد {@Request}", 
                requestName, elapsedMilliseconds, request);
        }

        return response;
    }
}
