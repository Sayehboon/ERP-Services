using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    public string Description { get; set; }

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
    public string ImageUrl { get; set; }

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
    public string Icon { get; set; }
    public string Color { get; set; }
    public string Code { get; set; }
}

/// <summary>
/// پیکربندی موجودیت دسته‌بندی
/// Category entity configuration
/// </summary>
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.ImageUrl).HasMaxLength(1000);
        builder.Property(e => e.Path).HasMaxLength(1000);
        builder.Property(e => e.Icon).HasMaxLength(100);
        builder.Property(e => e.Color).HasMaxLength(50);
        builder.Property(e => e.Code).HasMaxLength(100);

        builder.HasOne(e => e.ParentCategory)
            .WithMany(e => e.SubCategories)
            .HasForeignKey(e => e.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.Code).IsUnique(false);
        builder.HasIndex(e => e.Name);
        builder.HasIndex(e => e.ParentCategoryId);
    }
}
