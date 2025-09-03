namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;

/// <summary>
/// موجودیت سال مالی
/// Fiscal year entity
/// </summary>
public class FiscalYear : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// کد سال مالی
    /// Fiscal year code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ شروع سال مالی
    /// Fiscal year start date
    /// </summary>
    public DateTime YearStart { get; set; }

    /// <summary>
    /// تاریخ پایان سال مالی
    /// Fiscal year end date
    /// </summary>
    public DateTime YearEnd { get; set; }

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// دوره‌های مالی
    /// Fiscal periods
    /// </summary>
    public ICollection<FiscalPeriod> Periods { get; set; } = new List<FiscalPeriod>();
}

/// <summary>
/// موجودیت دوره مالی
/// Fiscal period entity
/// </summary>
public class FiscalPeriod : BaseEntity
{
    /// <summary>
    /// شماره دوره
    /// Period number
    /// </summary>
    public int PeriodNo { get; set; }

    /// <summary>
    /// نام دوره
    /// Period name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ شروع دوره
    /// Period start date
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان دوره
    /// Period end date
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// وضعیت دوره
    /// Period status
    /// </summary>
    public string Status { get; set; } = "open"; // open, closed

    /// <summary>
    /// شناسه سال مالی
    /// Fiscal year ID
    /// </summary>
    public Guid FiscalYearId { get; set; }
}
