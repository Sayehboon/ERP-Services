using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت کارمند
/// Employee entity
/// </summary>
public class Employee : BaseEntity
{
    /// <summary>
    /// نام کارمند
    /// Employee name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی کارمند
    /// Employee last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// کد ملی کارمند
    /// Employee national code
    /// </summary>
    public string? NationalCode { get; set; }

    /// <summary>
    /// شماره پرسنلی کارمند
    /// Employee personnel number
    /// </summary>
    public string? PersonnelNumber { get; set; }

    /// <summary>
    /// تاریخ استخدام
    /// Employment date
    /// </summary>
    public DateTime? EmploymentDate { get; set; }

    /// <summary>
    /// تاریخ ترک کار
    /// Termination date
    /// </summary>
    public DateTime? TerminationDate { get; set; }

    /// <summary>
    /// شناسه بخش
    /// Department ID
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// سمت کارمند
    /// Employee position
    /// </summary>
    public string? Position { get; set; }

    /// <summary>
    /// وضعیت کارمند
    /// Employee status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// شماره تلفن کارمند
    /// Employee phone number
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// ایمیل کارمند
    /// Employee email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// آدرس کارمند
    /// Employee address
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// وضعیت فعال بودن کارمند
    /// Employee active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation properties
    /// <summary>
    /// بخش
    /// Department
    /// </summary>
    public Department? Department { get; set; }

    /// <summary>
    /// حقوق‌ها
    /// Salaries
    /// </summary>
    public ICollection<EmployeeSalary> Salaries { get; set; } = new List<EmployeeSalary>();

    /// <summary>
    /// حضور و غیاب‌ها
    /// Attendances
    /// </summary>
    public ICollection<EmployeeAttendance> Attendances { get; set; } = new List<EmployeeAttendance>();

    /// <summary>
    /// مرخصی‌ها
    /// Leaves
    /// </summary>
    public ICollection<Leave> Leaves { get; set; } = new List<Leave>();
}
