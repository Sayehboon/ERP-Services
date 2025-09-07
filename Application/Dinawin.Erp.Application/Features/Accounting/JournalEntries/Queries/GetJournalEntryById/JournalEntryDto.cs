namespace Dinawin.Erp.Application.Features.Accounting.JournalEntries.Queries.GetJournalEntryById;

/// <summary>
/// مدل انتقال داده سند حسابداری
/// </summary>
public sealed class JournalEntryDto
{
    /// <summary>
    /// شناسه سند حسابداری
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// شماره سند
    /// </summary>
    public string EntryNumber { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ سند
    /// </summary>
    public DateTime EntryDate { get; set; }

    /// <summary>
    /// نوع سند
    /// </summary>
    public string EntryType { get; set; } = string.Empty;

    /// <summary>
    /// شرح سند
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// شناسه حساب
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// کد حساب
    /// </summary>
    public string AccountCode { get; set; } = string.Empty;

    /// <summary>
    /// نام حساب
    /// </summary>
    public string AccountName { get; set; } = string.Empty;

    /// <summary>
    /// مبلغ بدهکار
    /// </summary>
    public decimal DebitAmount { get; set; }

    /// <summary>
    /// مبلغ بستانکار
    /// </summary>
    public decimal CreditAmount { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    public string? Currency { get; set; }

    /// <summary>
    /// نرخ ارز
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// مرجع سند
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// شناسه سند مرجع
    /// </summary>
    public Guid? ReferenceId { get; set; }

    /// <summary>
    /// نوع سند مرجع
    /// </summary>
    public string? ReferenceType { get; set; }

    /// <summary>
    /// آیا سند تأیید شده است
    /// </summary>
    public bool IsApproved { get; set; }

    /// <summary>
    /// تاریخ تأیید
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// شناسه کاربر تأیید کننده
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
