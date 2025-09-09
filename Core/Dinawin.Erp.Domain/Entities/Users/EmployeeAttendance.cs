using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت حضور و غیاب کارمند
/// Employee Attendance entity
/// </summary>
public class EmployeeAttendance : BaseEntity
{
    /// <summary>
    /// شناسه کارمند
    /// Employee ID
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// تاریخ حضور
    /// Attendance date
    /// </summary>
    public DateTime AttendanceDate { get; set; }

    /// <summary>
    /// زمان ورود
    /// Check-in time
    /// </summary>
    public DateTime? CheckInTime { get; set; }

    /// <summary>
    /// زمان خروج
    /// Check-out time
    /// </summary>
    public DateTime? CheckOutTime { get; set; }

    /// <summary>
    /// ساعت کار
    /// Working hours
    /// </summary>
    public decimal? WorkingHours { get; set; }

    /// <summary>
    /// ساعت اضافه کار
    /// Overtime hours
    /// </summary>
    public decimal? OvertimeHours { get; set; }

    /// <summary>
    /// وضعیت حضور
    /// Attendance status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات حضور
    /// Attendance description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// یادداشت‌های حضور
    /// Attendance notes
    /// </summary>
    public string? Notes { get; set; }
}
