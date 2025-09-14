using FluentValidation;
using MediatR;

namespace Dinawin.Erp.Application.Common.Behaviors;

/// <summary>
/// رفتار اعتبارسنجی برای CQRS
/// Validation behavior for CQRS
/// </summary>
/// <typeparam name="TRequest">نوع درخواست</typeparam>
/// <typeparam name="TResponse">نوع پاسخ</typeparam>
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary>
    /// سازنده رفتار اعتبارسنجی
    /// Validation behavior constructor
    /// </summary>
    /// <param name="validators">اعتبارسنج‌ها</param>
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    /// <summary>
    /// اجرای رفتار اعتبارسنجی
    /// Execute validation behavior
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="next">عمل بعدی</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>پاسخ</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Any())
                throw new ValidationException(failures);
        }

        return await next();
    }
}
