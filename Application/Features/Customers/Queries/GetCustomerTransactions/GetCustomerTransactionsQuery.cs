using MediatR;

namespace Dinawin.Erp.Application.Features.Customers.Queries.GetCustomerTransactions;

/// <summary>
/// پرس‌وجو دریافت تراکنش‌های مشتری
/// </summary>
public sealed class GetCustomerTransactionsQuery : IRequest<IEnumerable<CustomerTransactionDto>>
{
    /// <summary>
    /// شناسه مشتری
    /// </summary>
    public required Guid CustomerId { get; init; }

    /// <summary>
    /// نوع تراکنش (اختیاری)
    /// </summary>
    public string TransactionType { get; init; }

    /// <summary>
    /// تاریخ شروع (اختیاری)
    /// </summary>
    public DateTime? FromDate { get; init; }

    /// <summary>
    /// تاریخ پایان (اختیاری)
    /// </summary>
    public DateTime? ToDate { get; init; }

    /// <summary>
    /// مبلغ حداقل (اختیاری)
    /// </summary>
    public decimal? MinAmount { get; init; }

    /// <summary>
    /// مبلغ حداکثر (اختیاری)
    /// </summary>
    public decimal? MaxAmount { get; init; }

    /// <summary>
    /// تعداد نتایج حداکثر
    /// </summary>
    public int MaxResults { get; init; } = 100;
}
