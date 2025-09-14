namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Queries.GetRolePermissions;

/// <summary>
/// DTO مجوز
/// </summary>
public class PermissionDto
{
    /// <summary>
    /// شناسه مجوز
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام مجوز
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات مجوز
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// دسته‌بندی مجوز
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
