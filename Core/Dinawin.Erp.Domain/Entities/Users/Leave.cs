using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت مرخصی
/// Leave entity
/// </summary>
public class Leave : BaseEntity
{
    /// <summary>
    /// شناسه کارمند
    /// Employee ID
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// نوع مرخصی
    /// Leave type
    /// </summary>
    public string LeaveType { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ شروع مرخصی
    /// Leave start date
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان مرخصی
    /// Leave end date
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// تعداد روزهای مرخصی
    /// Number of leave days
    /// </summary>
    public int Days { get; set; }

    /// <summary>
    /// دلیل مرخصی
    /// Leave reason
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// وضعیت درخواست مرخصی
    /// Leave request status
    /// </summary>
    public string Status { get; set; } = "pending"; // pending, approved, rejected

    /// <summary>
    /// تاریخ تایید/رد
    /// Approval/rejection date
    /// </summary>
    public DateTime? ProcessedDate { get; set; }

    /// <summary>
    /// شناسه کاربر تاییدکننده
    /// Approver user ID
    /// </summary>
    public Guid? ProcessedBy { get; set; }

    /// <summary>
    /// توضیحات تایید/رد
    /// Approval/rejection comments
    /// </summary>
    public string? ProcessedComments { get; set; }

    /// <summary>
    /// آیا مرخصی با حقوق است
    /// Is paid leave
    /// </summary>
    public bool IsPaidLeave { get; set; } = true;

    /// <summary>
    /// کارمند
    /// Employee
    /// </summary>
    public Employee? Employee { get; set; }

    /// <summary>
    /// کاربر تاییدکننده
    /// Approver user
    /// </summary>
    public User? ProcessedByUser { get; set; }
}
