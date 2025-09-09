using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// سال مالی
/// Fiscal Year
/// </summary>
public class AccFiscalYear : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام سال مالی
    /// Fiscal Year Name
    /// </summary>
    public string FiscalYearName { get; set; } = string.Empty;

    /// <summary>
    /// سال
    /// Year
    /// </summary>
    public int Year { get; set; }

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
    /// وضعیت سال مالی
    /// Fiscal Year Status
    /// </summary>
    public string Status { get; set; } = "open";

    /// <summary>
    /// آیا سال مالی بسته است
    /// Is Closed
    /// </summary>
    public bool IsClosed { get; set; } = false;

    /// <summary>
    /// تاریخ بسته شدن
    /// Close Date
    /// </summary>
    public DateTime? CloseDate { get; set; }

    /// <summary>
    /// شناسه کاربر بستن سال
    /// Closed By User ID
    /// </summary>
    public Guid? ClosedByUserId { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// آیا سال مالی قفل است
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

    /// <summary>
    /// ارز پایه
    /// Base Currency
    /// </summary>
    public string BaseCurrency { get; set; } = "IRR";

    /// <summary>
    /// تعداد دوره ها
    /// Number of Periods
    /// </summary>
    public int NumberOfPeriods { get; set; } = 12;

    /// <summary>
    /// نوع دوره
    /// Period Type
    /// </summary>
    public string PeriodType { get; set; } = "monthly";

    // Navigation Properties
    /// <summary>
    /// کاربر بستن سال
    /// Closed By User
    /// </summary>
    public virtual User? ClosedByUser { get; set; }

    /// <summary>
    /// کاربر قفل کننده
    /// Locked By User
    /// </summary>
    public virtual User? LockedByUser { get; set; }

    /// <summary>
    /// دوره های مالی
    /// Fiscal Periods
    /// </summary>
    public virtual ICollection<AccFiscalPeriod> FiscalPeriods { get; set; } = new List<AccFiscalPeriod>();
}
