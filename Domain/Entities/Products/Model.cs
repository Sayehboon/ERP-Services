using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// موجودیت مدل محصول
/// Product Model entity
/// </summary>
public class Model : BaseEntity
{
    /// <summary>
    /// نام مدل
    /// Model name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد مدل
    /// Model code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات مدل
    /// Model description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// شناسه برند
    /// Brand ID
    /// </summary>
    public Guid BrandId { get; set; }

    /// <summary>
    /// وضعیت فعال بودن مدل
    /// Model active status
    /// </summary>
    public bool IsActive { get; set; } = true;
    public Guid CategoryId { get; set; }
    public string YearRange { get; set; }

    /// <summary>
    /// ترتیب نمایش
    /// Sort order
    /// </summary>
    public int SortOrder { get; set; } = 0;

    /// <summary>
    /// برند مرتبط
    /// Related brand
    /// </summary>
    public Brand Brand { get; set; } = null!;

    /// <summary>
    /// محصولات این مدل
    /// Products of this model
    /// </summary>
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

/// <summary>
/// پیکربندی موجودیت مدل محصول
/// Product Model entity configuration
/// </summary>
public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Code).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.YearRange).HasMaxLength(50);

        builder.HasOne(e => e.Brand)
            .WithMany(b => b.Models)
            .HasForeignKey(e => e.BrandId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.Code).IsUnique(false);
        builder.HasIndex(e => e.Name);
        builder.HasIndex(e => e.BrandId);
        builder.HasIndex(e => e.CategoryId);
    }
}
