using MediatR;

namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetCashBoxTransactions;

/// <summary>
/// پرس‌وجو دریافت تراکنش‌های صندوق نقدی
/// </summary>
public sealed class GetCashBoxTransactionsQuery : IRequest<IEnumerable<CashBoxTransactionDto>>
{
    /// <summary>
    /// شناسه صندوق نقدی
    /// </summary>
    public required Guid CashBoxId { get; init; }

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
