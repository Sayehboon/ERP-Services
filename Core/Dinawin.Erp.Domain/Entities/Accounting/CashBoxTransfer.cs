using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// انتقال بین صندوق‌ها
/// </summary>
public class CashBoxTransfer : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه صندوق مبدا
    /// </summary>
    public Guid SourceCashBoxId { get; set; }

    /// <summary>
    /// شناسه صندوق مقصد
    /// </summary>
    public Guid TargetCashBoxId { get; set; }

    /// <summary>
    /// تاریخ انتقال
    /// </summary>
    public DateTime TransferDate { get; set; }

    /// <summary>
    /// مبلغ انتقال
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// مبلغ به ارز اصلی
    /// </summary>
    public decimal? AmountInBaseCurrency { get; set; }

    /// <summary>
    /// شماره مرجع
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// وضعیت انتقال
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// شناسه کاربر تاییدکننده
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// تاریخ تایید
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// صندوق مبدا
    /// </summary>
    public Treasury.CashBox SourceCashBox { get; set; } = null!;

    /// <summary>
    /// صندوق مقصد
    /// </summary>
    public Treasury.CashBox TargetCashBox { get; set; } = null!;

    /// <summary>
    /// کاربر ایجادکننده
    /// </summary>
    public Users.User? CreatedByUser { get; set; }

    /// <summary>
    /// کاربر تاییدکننده
    /// </summary>
    public Users.User? ApprovedByUser { get; set; }
}
