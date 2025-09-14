using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Inventories;

/// <summary>
/// بارکد موجودی
/// Inventory Barcode
/// </summary>
public class InventoryBarcode : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه محصول
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// کد بارکد
    /// Barcode code
    /// </summary>
    public string Barcode { get; set; } = string.Empty;

    /// <summary>
    /// نوع بارکد
    /// Barcode type
    /// </summary>
    public string BarcodeType { get; set; } = string.Empty;

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// محصول مرتبط
    /// Related product
    /// </summary>
    public Products.Product Product { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت بارکد موجودی
/// Inventory Barcode entity configuration
/// </summary>
public class InventoryBarcodeConfiguration : IEntityTypeConfiguration<InventoryBarcode>
{
    public void Configure(EntityTypeBuilder<InventoryBarcode> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Barcode).IsRequired().HasMaxLength(100);
        builder.Property(e => e.BarcodeType).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(500);

        builder.HasOne(e => e.Product)
            .WithMany()
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.Barcode).IsUnique();
        builder.HasIndex(e => e.ProductId);
    }
}
