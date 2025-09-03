using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dinawin.Erp.Domain.Entities.Products;

namespace Dinawin.Erp.Persistence.Configurations;

/// <summary>
/// پیکربندی موجودیت کالا
/// Product entity configuration
/// </summary>
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    /// <summary>
    /// پیکربندی موجودیت کالا
    /// Configure product entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", "Product");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Sku)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .HasMaxLength(1000);

        // پیکربندی Value Objects
        builder.OwnsOne(p => p.PurchasePrice, money =>
        {
            money.Property(m => m.Amount)
                .HasColumnName("PurchasePrice")
                .HasColumnType("decimal(18,2)");
            
            money.Property(m => m.Currency)
                .HasColumnName("PurchaseCurrency")
                .HasMaxLength(3)
                .HasDefaultValue("IRR");
        });

        builder.OwnsOne(p => p.SellingPrice, money =>
        {
            money.Property(m => m.Amount)
                .HasColumnName("SellingPrice")
                .HasColumnType("decimal(18,2)");
            
            money.Property(m => m.Currency)
                .HasColumnName("SellingCurrency")
                .HasMaxLength(3)
                .HasDefaultValue("IRR");
        });

        builder.OwnsOne(p => p.Weight, weight =>
        {
            weight.Property(w => w.Value)
                .HasColumnName("WeightValue")
                .HasColumnType("decimal(18,4)");
            
            weight.Property(w => w.Unit)
                .HasColumnName("WeightUnit")
                .HasConversion<int>();
        });

        builder.OwnsOne(p => p.Dimensions, dimensions =>
        {
            dimensions.Property(d => d.Length)
                .HasColumnName("DimensionLength")
                .HasColumnType("decimal(18,4)");
            
            dimensions.Property(d => d.Width)
                .HasColumnName("DimensionWidth")
                .HasColumnType("decimal(18,4)");
            
            dimensions.Property(d => d.Height)
                .HasColumnName("DimensionHeight")
                .HasColumnType("decimal(18,4)");
            
            dimensions.Property(d => d.Unit)
                .HasColumnName("DimensionUnit")
                .HasConversion<int>();
        });

        // روابط
        builder.HasOne(p => p.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(p => p.BaseUom)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.BaseUomId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(p => p.Inventories)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // ایندکس‌ها
        builder.HasIndex(p => p.Sku)
            .IsUnique()
            .HasDatabaseName("IX_Products_Sku");

        builder.HasIndex(p => p.Name)
            .HasDatabaseName("IX_Products_Name");

        builder.HasIndex(p => p.BrandId)
            .HasDatabaseName("IX_Products_BrandId");

        builder.HasIndex(p => p.CategoryId)
            .HasDatabaseName("IX_Products_CategoryId");
    }
}
