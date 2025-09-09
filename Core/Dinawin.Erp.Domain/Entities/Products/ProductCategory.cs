using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// موجودیت دسته‌بندی محصول
/// Product Category entity
/// </summary>
public class ProductCategory : BaseEntity
{
    /// <summary>
    /// نام دسته‌بندی
    /// Category name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد دسته‌بندی
    /// Category code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات دسته‌بندی
    /// Category description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه دسته‌بندی والد
    /// Parent category ID
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// سطح دسته‌بندی
    /// Category level
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// مسیر دسته‌بندی
    /// Category path
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// وضعیت فعال بودن دسته‌بندی
    /// Category active status
    /// </summary>
    public bool IsActive { get; set; } = true;
}
