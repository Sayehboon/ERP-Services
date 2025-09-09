using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class GrnReceipt : BaseEntity, IAggregateRoot
{
    public Guid VendorId { get; set; }
    public Guid WarehouseId { get; set; }
    public DateTime ReceiptDate { get; set; } = DateTime.UtcNow;
    public string? Number { get; set; }
    public string Status { get; set; } = "draft";
    public string Currency { get; set; } = "IRR";
    public decimal? ExchangeRate { get; set; }
    public decimal Subtotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal Total { get; set; }
    public Guid? PoOrderId { get; set; }

    // Navigation
    public Warehouse Warehouse { get; set; } = null!;
    public ICollection<GrnLine> Lines { get; set; } = new List<GrnLine>();
}

/// <summary>
/// پیکربندی موجودیت رسید کالا
/// GRN Receipt entity configuration
/// </summary>
public class GrnReceiptConfiguration : IEntityTypeConfiguration<GrnReceipt>
{
    public void Configure(EntityTypeBuilder<GrnReceipt> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Number).HasMaxLength(100);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);

        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        builder.Property(e => e.Subtotal).HasPrecision(18, 2);
        builder.Property(e => e.TaxAmount).HasPrecision(18, 2);
        builder.Property(e => e.Total).HasPrecision(18, 2);

        builder.HasOne(e => e.Warehouse)
            .WithMany()
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.Number).IsUnique(false);
        builder.HasIndex(e => e.ReceiptDate);
        builder.HasIndex(e => e.VendorId);
        builder.HasIndex(e => e.Status);
    }
}

