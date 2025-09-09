using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// لاگ تایید اسناد حسابداری
/// Accounting Journal Approval Log
/// </summary>
public class AccJournalApprovalLog : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه سند حسابداری
    /// Journal Voucher ID
    /// </summary>
    public Guid JournalVoucherId { get; set; }

    /// <summary>
    /// شناسه کاربر تایید کننده
    /// Approver User ID
    /// </summary>
    public Guid ApproverUserId { get; set; }

    /// <summary>
    /// تاریخ تایید
    /// Approval Date
    /// </summary>
    public DateTime ApprovalDate { get; set; }

    /// <summary>
    /// وضعیت تایید
    /// Approval Status
    /// </summary>
    public string ApprovalStatus { get; set; } = string.Empty;

    /// <summary>
    /// نظرات تایید کننده
    /// Approver Comments
    /// </summary>
    public string? ApproverComments { get; set; }

    /// <summary>
    /// مرحله تایید
    /// Approval Stage
    /// </summary>
    public int ApprovalStage { get; set; } = 1;

    /// <summary>
    /// آیا تایید نهایی است
    /// Is Final Approval
    /// </summary>
    public bool IsFinalApproval { get; set; } = false;

    /// <summary>
    /// تاریخ انقضا
    /// Expiry Date
    /// </summary>
    public DateTime? ExpiryDate { get; set; }

    /// <summary>
    /// مدت زمان تایید (دقیقه)
    /// Approval Duration (minutes)
    /// </summary>
    public int? ApprovalDurationMinutes { get; set; }

    /// <summary>
    /// نوع تایید
    /// Approval Type
    /// </summary>
    public string? ApprovalType { get; set; }

    // Navigation Properties
    /// <summary>
    /// سند حسابداری
    /// Journal Voucher
    /// </summary>
    public virtual AccJournalVoucher? JournalVoucher { get; set; }

    /// <summary>
    /// کاربر تایید کننده
    /// Approver User
    /// </summary>
    public virtual User? ApproverUser { get; set; }
}
