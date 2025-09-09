using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// موجودیت دسته‌بندی
/// Category entity
/// </summary>
public class Category : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام دسته‌بندی
    /// Category name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// توضیحات دسته‌بندی
    /// Category description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه دسته‌بندی والد
    /// Parent category ID
    /// </summary>
    public Guid? ParentCategoryId { get; set; }

    /// <summary>
    /// دسته‌بندی والد
    /// Parent category
    /// </summary>
    public Category? ParentCategory { get; set; }

    /// <summary>
    /// زیردسته‌ها
    /// Subcategories
    /// </summary>
    public ICollection<Category> SubCategories { get; set; } = new List<Category>();

    /// <summary>
    /// آدرس تصویر
    /// Image URL
    /// </summary>
    public string? ImageUrl { get; set; }

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
    /// مسیر کامل دسته‌بندی
    /// Full category path
    /// </summary>
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// سطح دسته‌بندی
    /// Category level
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// کالاهای این دسته‌بندی
    /// Products of this category
    /// </summary>
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public string? Icon { get; set; }
    public string? Color { get; set; }
    public string Code { get; set; }
}
