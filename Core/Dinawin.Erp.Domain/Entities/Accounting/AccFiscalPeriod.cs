using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// دوره مالی
/// Fiscal Period
/// </summary>
public class AccFiscalPeriod : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه سال مالی
    /// Fiscal Year ID
    /// </summary>
    public Guid FiscalYearId { get; set; }

    /// <summary>
    /// نام دوره
    /// Period Name
    /// </summary>
    public string PeriodName { get; set; } = string.Empty;

    /// <summary>
    /// شماره دوره
    /// Period Number
    /// </summary>
    public int PeriodNumber { get; set; }

    /// <summary>
    /// تاریخ شروع
    /// Start Date
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان
    /// End Date
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// وضعیت دوره
    /// Period Status
    /// </summary>
    public string Status { get; set; } = "open";

    /// <summary>
    /// آیا دوره بسته است
    /// Is Closed
    /// </summary>
    public bool IsClosed { get; set; } = false;

    /// <summary>
    /// تاریخ بسته شدن
    /// Close Date
    /// </summary>
    public DateTime? CloseDate { get; set; }

    /// <summary>
    /// شناسه کاربر بستن دوره
    /// Closed By User ID
    /// </summary>
    public Guid? ClosedByUserId { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// آیا دوره قفل است
    /// Is Locked
    /// </summary>
    public bool IsLocked { get; set; } = false;

    /// <summary>
    /// تاریخ قفل شدن
    /// Lock Date
    /// </summary>
    public DateTime? LockDate { get; set; }

    /// <summary>
    /// شناسه کاربر قفل کننده
    /// Locked By User ID
    /// </summary>
    public Guid? LockedByUserId { get; set; }

    // Navigation Properties
    /// <summary>
    /// سال مالی
    /// Fiscal Year
    /// </summary>
    public virtual AccFiscalYear? FiscalYear { get; set; }

    /// <summary>
    /// کاربر بستن دوره
    /// Closed By User
    /// </summary>
    public virtual User? ClosedByUser { get; set; }

    /// <summary>
    /// کاربر قفل کننده
    /// Locked By User
    /// </summary>
    public virtual User? LockedByUser { get; set; }
}
