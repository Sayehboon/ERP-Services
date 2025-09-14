using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// موجودیت برند
/// Brand entity
/// </summary>
public class Brand : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام برند
    /// Brand name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// توضیحات برند
    /// Brand description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// آدرس لوگو
    /// Logo URL
    /// </summary>
    public string LogoUrl { get; set; }

    /// <summary>
    /// وب‌سایت برند
    /// Brand website
    /// </summary>
    public string Website { get; set; }

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
    /// کالاهای این برند
    /// Products of this brand
    /// </summary>
    public ICollection<Product> Products { get; set; } = new List<Product>();

    /// <summary>
    /// مدل‌های این برند
    /// Models of this brand
    /// </summary>
    public ICollection<Model> Models { get; set; } = new List<Model>();

    public string Code { get; set; }
    public string Country { get; set; }
    public Guid? CategoryId { get; set; }
}

/// <summary>
/// پیکربندی موجودیت برند
/// Brand entity configuration
/// </summary>
public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.LogoUrl).HasMaxLength(1000);
        builder.Property(e => e.Website).HasMaxLength(200);
        builder.Property(e => e.Code).HasMaxLength(100);
        builder.Property(e => e.Country).HasMaxLength(100);

        builder.HasIndex(e => e.Code).IsUnique(false);
        builder.HasIndex(e => e.Name);
    }
}
