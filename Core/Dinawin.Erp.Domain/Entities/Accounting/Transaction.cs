using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// موجودیت تراکنش حسابداری
/// Accounting Transaction entity
/// </summary>
public class Transaction : BaseEntity
{
    /// <summary>
    /// شماره تراکنش
    /// Transaction number
    /// </summary>
    public string TransactionNumber { get; set; } = string.Empty;

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
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>
    

    /// <summary>
    /// یادداشت‌های تراکنش
    /// Transaction notes
    /// </summary>
    public string? Notes { get; set; }
}
