using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dinawin.Erp.Domain.Entities.Products;

namespace Dinawin.Erp.Persistence.Configurations;

/// <summary>
/// پیکربندی موجودیت دسته‌بندی
/// Category entity configuration
/// </summary>
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    /// <summary>
    /// پیکربندی موجودیت دسته‌بندی
    /// Configure category entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories", "Product");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Description)
            .HasMaxLength(1000);

        builder.Property(c => c.ImageUrl)
            .HasMaxLength(500);

        builder.Property(c => c.Path)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(c => c.Level)
            .IsRequired();

        builder.Property(c => c.SortOrder)
            .HasDefaultValue(0);

        // روابط
        builder.HasOne(c => c.ParentCategory)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(c => c.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        // ایندکس‌ها
        builder.HasIndex(c => c.Name)
            .HasDatabaseName("IX_Categories_Name");

        builder.HasIndex(c => c.ParentCategoryId)
            .HasDatabaseName("IX_Categories_ParentCategoryId");

        builder.HasIndex(c => new { c.Level, c.SortOrder })
            .HasDatabaseName("IX_Categories_Level_SortOrder");

        builder.HasIndex(c => c.Path)
            .HasDatabaseName("IX_Categories_Path");
    }
}
