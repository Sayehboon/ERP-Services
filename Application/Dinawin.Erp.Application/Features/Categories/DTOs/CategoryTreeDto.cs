namespace Dinawin.Erp.Application.Features.Categories.DTOs;

/// <summary>
/// DTO درخت دسته‌بندی
/// </summary>
public class CategoryTreeDto
{
    /// <summary>
    /// شناسه دسته‌بندی
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام دسته‌بندی
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات دسته‌بندی
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// شناسه دسته‌بندی والد
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// دسته‌بندی‌های فرزند
    /// </summary>
    public List<CategoryTreeDto> Children { get; set; } = new();
}
