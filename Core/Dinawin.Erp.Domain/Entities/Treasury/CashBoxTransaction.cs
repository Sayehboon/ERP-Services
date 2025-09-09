using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Treasury;

/// <summary>
/// موجودیت تراکنش صندوق نقدی
/// Cash Box Transaction entity
/// </summary>
public class CashBoxTransaction : BaseEntity
{
    /// <summary>
    /// شناسه صندوق نقدی
    /// Cash box ID
    /// </summary>
    public Guid CashBoxId { get; set; }

    /// <summary>
    /// نوع تراکنش
    /// Transaction type
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// مبلغ تراکنش
    /// Transaction amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// ارز تراکنش
    /// Transaction currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// توضیحات تراکنش
    /// Transaction description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شماره مرجع
    /// Reference number
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// تاریخ تراکنش
    /// Transaction date
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// شناسه کاربر تاییدکننده
    /// Approved by user ID
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// یادداشت‌های تراکنش
    /// Transaction notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// صندوق نقدی مرتبط
    /// Related cash box
    /// </summary>
    public CashBox? CashBox { get; set; }

    /// <summary>
    /// کاربر ایجادکننده تراکنش
    /// Created by user
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Users.User? CreatedByUser { get; set; }

    /// <summary>
    /// کاربر تاییدکننده تراکنش
    /// Approved by user
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Users.User? ApprovedByUser { get; set; }
    public decimal? BalanceBefore { get; set; }
    public string Status { get; set; }
    public decimal? BalanceAfter { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public string TransactionType { get; set; }
    public decimal? ExchangeRate { get; set; }
    public decimal? AmountInBaseCurrency { get; set; }
}
