namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Queries.GetAllRoles;

/// <summary>
/// DTO نقش
/// </summary>
public class RoleDto
{
    /// <summary>
    /// شناسه نقش
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام نقش
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات نقش
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// مجوزهای نقش
    /// </summary>
    public List<string> Permissions { get; set; } = new();

    /// <summary>
    /// تعداد کاربران
    /// </summary>
    public int UsersCount { get; set; }

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
