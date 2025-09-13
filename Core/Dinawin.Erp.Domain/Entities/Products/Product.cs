using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Inventories;
using Dinawin.Erp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// انواع کالا
/// Product types
/// </summary>
public enum ProductType
{
    /// <summary>
    /// کالای فیزیکی
    /// Physical product
    /// </summary>
    Physical = 1,

    /// <summary>
    /// کالای دیجیتال
    /// Digital product
    /// </summary>
    Digital = 2,

    /// <summary>
    /// خدمات
    /// Service
    /// </summary>
    Service = 3
}

/// <summary>
/// موجودیت کالا
/// Product entity
/// </summary>
public class Product : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// کد SKU کالا
    /// Product SKU code
    /// </summary>
    public required string Sku { get; set; }

    /// <summary>
    /// نام کالا
    /// Product name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// توضیحات کالا
    /// Product description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه برند
    /// Brand ID
    /// </summary>
    public Guid? BrandId { get; set; }

    /// <summary>
    /// برند
    /// Brand
    /// </summary>
    public Brand? Brand { get; set; }

    /// <summary>
    /// شناسه دسته‌بندی
    /// Category ID
    /// </summary>
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// دسته‌بندی
    /// Category
    /// </summary>
    public Category? Category { get; set; }

    /// <summary>
    /// شناسه واحد پایه
    /// Base unit of measure ID
    /// </summary>
    public Guid? BaseUomId { get; set; }

    /// <summary>
    /// شناسه واحد (نام مستعار)
    /// Unit ID (alias)
    /// </summary>
    public Guid? UomId { get; set; }

    /// <summary>
    /// واحد پایه
    /// Base unit of measure
    /// </summary>
    public UnitOfMeasure? BaseUom { get; set; }

    /// <summary>
    /// واحد اندازه‌گیری (نام مستعار)
    /// Unit of measure (alias)
    /// </summary>
    public UnitOfMeasure? Unit => BaseUom;

    /// <summary>
    /// واحد پیش‌فرض (Supabase: default_unit)
    /// Default unit (Supabase: default_unit)
    /// </summary>
    public string? DefaultUnit { get; set; }

    /// <summary>
    /// قیمت خرید
    /// Purchase price
    /// </summary>
    public Money? PurchasePrice { get; set; }

    /// <summary>
    /// قیمت فروش
    /// Selling price
    /// </summary>
    public Money? SellingPrice { get; set; }

    /// <summary>
    /// حداقل موجودی
    /// Minimum stock level
    /// </summary>
    public decimal MinStockLevel { get; set; }

    /// <summary>
    /// حداقل موجودی (نام مستعار)
    /// Minimum stock (alias)
    /// </summary>
    public decimal MinStock { get; set; } = 0;

    /// <summary>
    /// حداکثر موجودی
    /// Maximum stock level
    /// </summary>
    public decimal MaxStockLevel { get; set; }

    /// <summary>
    /// حداکثر موجودی (نام مستعار)
    /// Maximum stock (alias)
    /// </summary>
    public decimal MaxStock { get; set; } = 0;

    /// <summary>
    /// نقطه سفارش مجدد
    /// Reorder point
    /// </summary>
    public decimal ReorderPoint { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// نوع کالا
    /// Product type
    /// </summary>
    public ProductType Type { get; set; }

    /// <summary>
    /// وزن کالا
    /// Product weight
    /// </summary>
    public Weight? Weight { get; set; }

    /// <summary>
    /// ابعاد کالا
    /// Product dimensions
    /// </summary>
    public Dimensions? Dimensions { get; set; }

    /// <summary>
    /// موجودی‌های کالا در انبارها
    /// Product inventories in warehouses
    /// </summary>
    public ICollection<Inventory> Inventories { get; set; } = [];

    /// <summary>
    /// ویژگی‌های کالا (Supabase: product_attributes)
    /// Product attributes
    /// </summary>
    public ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();

    /// <summary>
    /// تصاویر کالا (Supabase: product_images)
    /// Product images
    /// </summary>
    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();

    /// <summary>
    /// فایل‌های پیوست کالا (Supabase: product_files)
    /// Product files
    /// </summary>
    public ICollection<ProductFile> Files { get; set; } = new List<ProductFile>();

    /// <summary>
    /// سازگاری با خودروها (Supabase: vehicle_compatibility)
    /// Vehicle compatibilities
    /// </summary>
    public ICollection<VehicleCompatibility> VehicleCompatibilities { get; set; } = new List<VehicleCompatibility>();

    /// <summary>
    /// حرکات موجودی کالا
    /// Product inventory movements
    /// </summary>
    public ICollection<InventoryMovement> InventoryMovements { get; set; } = [];
    public string? Code { get; set; }
    public Guid? ModelId { get; set; }
    public Guid? TrimId { get; set; }
    public Guid? YearId { get; set; }
    public Guid? UnitId { get; set; }

    /// <summary>
    /// مدل مرتبط
    /// Related model
    /// </summary>
    public Model? Model { get; set; }

    /// <summary>
    /// تریم مرتبط
    /// Related trim
    /// </summary>
    public Trim? Trim { get; set; }

    /// <summary>
    /// سال مرتبط
    /// Related year
    /// </summary>
    public Year? Year { get; set; }
    public bool IsPurchasable { get; set; }
    public bool IsSellable { get; set; }
    public string Status { get; set; }
    public string? ProductType { get; set; }
    public string? Color { get; set; }
    public decimal CurrentStock { get; set; }
    public decimal WholesalePrice { get; set; }
    public decimal SalePrice { get; set; }
    public bool IsManufacturable { get; set; }
}

/// <summary>
/// پیکربندی موجودیت کالا
/// Product entity configuration
/// </summary>
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Sku)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(e => e.Description)
            .HasMaxLength(2000);

        builder.Property(e => e.DefaultUnit)
            .HasMaxLength(50);

        builder.Property(e => e.Code).HasMaxLength(100);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.ProductType).HasMaxLength(50);
        builder.Property(e => e.Color).HasMaxLength(50);
        builder.Property(e => e.MinStock).HasPrecision(18, 4);
        builder.Property(e => e.MaxStock).HasPrecision(18, 4);
        builder.Property(e => e.CurrentStock).HasPrecision(18, 4);
        builder.Property(e => e.WholesalePrice).HasPrecision(18, 2);
        builder.Property(e => e.SalePrice).HasPrecision(18, 2);
        builder.Property(e => e.MinStockLevel).HasPrecision(18, 4);
        builder.Property(e => e.MaxStockLevel).HasPrecision(18, 4);
        builder.Property(e => e.ReorderPoint).HasPrecision(18, 4);

        // Configure value objects
        builder.OwnsOne(e => e.Weight, weight =>
        {
            weight.Property(w => w.Value).HasPrecision(18, 4);
            weight.Property(w => w.Unit).HasMaxLength(20);
        });

        builder.OwnsOne(e => e.Dimensions, dimensions =>
        {
            dimensions.Property(d => d.Length).HasPrecision(18, 4);
            dimensions.Property(d => d.Width).HasPrecision(18, 4);
            dimensions.Property(d => d.Height).HasPrecision(18, 4);
            dimensions.Property(d => d.Unit).HasMaxLength(20);
        });

        builder.OwnsOne(e => e.PurchasePrice, price =>
        {
            price.Property(p => p.Amount).HasPrecision(18, 2);
            price.Property(p => p.Currency).HasMaxLength(10);
        });

        builder.OwnsOne(e => e.SellingPrice, price =>
        {
            price.Property(p => p.Amount).HasPrecision(18, 2);
            price.Property(p => p.Currency).HasMaxLength(10);
        });

        builder.HasOne(e => e.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(e => e.BrandId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.BaseUom)
            .WithMany()
            .HasForeignKey(e => e.BaseUomId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.Model)
            .WithMany()
            .HasForeignKey(e => e.ModelId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.Trim)
            .WithMany()
            .HasForeignKey(e => e.TrimId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasIndex(e => e.Sku).IsUnique();
        builder.HasIndex(e => e.Name);
    }
}
