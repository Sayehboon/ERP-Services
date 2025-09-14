namespace Dinawin.Erp.Application.Features.HR.Departments.Queries.GetDepartmentById;

/// <summary>
/// مدل انتقال داده بخش
/// </summary>
public sealed class DepartmentDto
{
    /// <summary>
    /// شناسه بخش
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام بخش
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد بخش
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات بخش
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// شناسه بخش والد
    /// </summary>
    public Guid? ParentDepartmentId { get; set; }

    /// <summary>
    /// نام بخش والد
    /// </summary>
    public string ParentDepartmentName { get; set; }

    /// <summary>
    /// شناسه مدیر بخش
    /// </summary>
    public Guid? ManagerId { get; set; }

    /// <summary>
    /// نام مدیر بخش
    /// </summary>
    public string ManagerName { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// نوع بخش
    /// </summary>
    public string DepartmentType { get; set; }

    /// <summary>
    /// سطح بخش در سلسله مراتب
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// مسیر سلسله مراتبی
    /// </summary>
    public string HierarchyPath { get; set; }

    /// <summary>
    /// بودجه بخش
    /// </summary>
    public decimal? Budget { get; set; }

    /// <summary>
    /// آدرس بخش
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// شماره تلفن بخش
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// آدرس ایمیل بخش
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// آیا بخش فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// تعداد کارمندان
    /// </summary>
    public int EmployeeCount { get; set; }

    /// <summary>
    /// تعداد زیربخش‌ها
    /// </summary>
    public int SubDepartmentCount { get; set; }

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
