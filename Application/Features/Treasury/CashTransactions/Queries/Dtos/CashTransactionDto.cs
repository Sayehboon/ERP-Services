namespace Dinawin.Erp.Application.Features.Treasury.CashTransactions.Queries.Dtos;

/// <summary>
/// DTO تراکنش نقدی
/// Cash transaction DTO
/// </summary>
public class CashTransactionDto
{
    /// <summary>
    /// شناسه
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه صندوق نقدی
    /// Cash box ID
    /// </summary>
    public Guid CashBoxId { get; set; }

    /// <summary>
    /// نام صندوق نقدی
    /// Cash box name
    /// </summary>
    public string CashBoxName { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ تراکنش
    /// Transaction date
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// نوع تراکنش
    /// Transaction type
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// مبلغ
    /// Amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// شرح
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// وضعیت
    /// Status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// آیا پست شده است؟
    /// Is posted?
    /// </summary>
    public bool IsPosted { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// Created at
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
