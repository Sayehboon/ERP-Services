namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeAttendance;

/// <summary>
/// DTO حضور و غیاب کارمند
/// </summary>
public class EmployeeAttendanceDto
{
    /// <summary>
    /// شناسه حضور و غیاب
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کارمند
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// نام کارمند
    /// </summary>
    public string EmployeeName { get; set; } = string.Empty;

    /// <summary>
    /// کد کارمند
    /// </summary>
    public string EmployeeCode { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ حضور
    /// </summary>
    public DateTime AttendanceDate { get; set; }

    /// <summary>
    /// ساعت ورود
    /// </summary>
    public DateTime? CheckInTime { get; set; }

    /// <summary>
    /// ساعت خروج
    /// </summary>
    public DateTime? CheckOutTime { get; set; }

    /// <summary>
    /// مدت زمان کار (دقیقه)
    /// </summary>
    public int? WorkDurationMinutes { get; set; }

    /// <summary>
    /// مدت زمان کار (ساعت)
    /// </summary>
    public decimal? WorkDurationHours => WorkDurationMinutes.HasValue ? 
        Math.Round(WorkDurationMinutes.Value / 60.0m, 2) : null;

    /// <summary>
    /// نوع حضور
    /// </summary>
    public string AttendanceType { get; set; } = string.Empty;

    /// <summary>
    /// نوع حضور به فارسی
    /// </summary>
    public string AttendanceTypePersian { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت حضور
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت حضور به فارسی
    /// </summary>
    public string StatusPersian { get; set; } = string.Empty;

    /// <summary>
    /// ساعت شروع کار برنامه‌ریزی شده
    /// </summary>
    public DateTime? ScheduledStartTime { get; set; }

    /// <summary>
    /// ساعت پایان کار برنامه‌ریزی شده
    /// </summary>
    public DateTime? ScheduledEndTime { get; set; }

    /// <summary>
    /// تاخیر در ورود (دقیقه)
    /// </summary>
    public int? LateArrivalMinutes { get; set; }

    /// <summary>
    /// زودتر خروج (دقیقه)
    /// </summary>
    public int? EarlyDepartureMinutes { get; set; }

    /// <summary>
    /// اضافه کار (دقیقه)
    /// </summary>
    public int? OvertimeMinutes { get; set; }

    /// <summary>
    /// اضافه کار (ساعت)
    /// </summary>
    public decimal? OvertimeHours => OvertimeMinutes.HasValue ? 
        Math.Round(OvertimeMinutes.Value / 60.0m, 2) : null;

    /// <summary>
    /// ساعت استراحت
    /// </summary>
    public int? BreakMinutes { get; set; }

    /// <summary>
    /// ساعت استراحت (ساعت)
    /// </summary>
    public decimal? BreakHours => BreakMinutes.HasValue ? 
        Math.Round(BreakMinutes.Value / 60.0m, 2) : null;

    /// <summary>
    /// مکان ورود
    /// </summary>
    public string CheckInLocation { get; set; }

    /// <summary>
    /// مکان خروج
    /// </summary>
    public string CheckOutLocation { get; set; }

    /// <summary>
    /// دستگاه ورود
    /// </summary>
    public string CheckInDevice { get; set; }

    /// <summary>
    /// دستگاه خروج
    /// </summary>
    public string CheckOutDevice { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// یادداشت‌های مدیر
    /// </summary>
    public string ManagerNotes { get; set; }

    /// <summary>
    /// آیا تایید شده است
    /// </summary>
    public bool IsApproved { get; set; }

    /// <summary>
    /// شناسه کاربر تاییدکننده
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// نام کاربر تاییدکننده
    /// </summary>
    public string ApprovedByName { get; set; }

    /// <summary>
    /// تاریخ تایید
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// نام کاربر ایجادکننده
    /// </summary>
    public string CreatedByName { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// شناسه بخش
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// نام بخش
    /// </summary>
    public string DepartmentName { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string CompanyName { get; set; }
}
