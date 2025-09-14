using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    public string Description { get; set; }

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
    public string Path { get; set; }

    /// <summary>
    /// وضعیت فعال بودن دسته‌بندی
    /// Category active status
    /// </summary>
    public bool IsActive { get; set; } = true;
}

/// <summary>
/// پیکربندی موجودیت دسته‌بندی محصول
/// Product Category entity configuration
/// </summary>
public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Code).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Path).HasMaxLength(500);

        builder.HasIndex(e => e.Code).IsUnique(false);
        builder.HasIndex(e => e.Name);
        builder.HasIndex(e => e.ParentId);
    }
}
