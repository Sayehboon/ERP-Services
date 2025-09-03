using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت بخش
/// Department entity
/// </summary>
public class Department : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام بخش
    /// Department name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// کد بخش
    /// Department code
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// توضیحات بخش
    /// Department description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// Company ID
    /// </summary>
    public required Guid CompanyId { get; set; }

    /// <summary>
    /// شرکت
    /// Company
    /// </summary>
    public Company Company { get; set; } = null!;

    /// <summary>
    /// شناسه بخش والد
    /// Parent department ID
    /// </summary>
    public Guid? ParentDepartmentId { get; set; }

    /// <summary>
    /// بخش والد
    /// Parent department
    /// </summary>
    public Department? ParentDepartment { get; set; }

    /// <summary>
    /// زیربخش‌ها
    /// Sub-departments
    /// </summary>
    public ICollection<Department> SubDepartments { get; set; } = new List<Department>();

    /// <summary>
    /// شناسه مدیر بخش
    /// Department manager ID
    /// </summary>
    public Guid? ManagerId { get; set; }

    /// <summary>
    /// مدیر بخش
    /// Department manager
    /// </summary>
    public User? Manager { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// ترتیب نمایش
    /// Display order
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// مسیر کامل بخش
    /// Full department path
    /// </summary>
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// سطح بخش
    /// Department level
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// کاربران این بخش
    /// Department users
    /// </summary>
    public ICollection<User> Users { get; set; } = new List<User>();
}
