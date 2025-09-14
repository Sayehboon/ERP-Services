namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.SearchEmployees;

/// <summary>
/// DTO جستجوی کارمند
/// </summary>
public class EmployeeSearchDto
{
    /// <summary>
    /// شناسه کارمند
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// کد کارمند
    /// </summary>
    public string EmployeeCode { get; set; } = string.Empty;

    /// <summary>
    /// نام
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// نام کامل
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";

    /// <summary>
    /// ایمیل
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// تلفن
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// شناسه بخش
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// نام بخش
    /// </summary>
    public string DepartmentName { get; set; }

    /// <summary>
    /// موقعیت شغلی
    /// </summary>
    public string Position { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }
}
