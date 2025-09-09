using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class InventoryTransferNote : BaseEntity, IAggregateRoot
{
    public Guid FromWarehouseId { get; set; }
    public Guid ToWarehouseId { get; set; }
    public DateTime TransferDate { get; set; } = DateTime.UtcNow;
    public string Currency { get; set; } = "IRR";
    public string Status { get; set; } = "draft";
    public string? Number { get; set; }
    public decimal? Total { get; set; }

    // Navigation
    public Warehouse FromWarehouse { get; set; } = null!;
    public Warehouse ToWarehouse { get; set; } = null!;
    public ICollection<InventoryTransferLine> Lines { get; set; } = new List<InventoryTransferLine>();
}

/// <summary>
/// پیکربندی موجودیت یادداشت انتقال موجودی
/// Inventory Transfer Note entity configuration
/// </summary>
public class InventoryTransferNoteConfiguration : IEntityTypeConfiguration<InventoryTransferNote>
{
    public void Configure(EntityTypeBuilder<InventoryTransferNote> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Number).HasMaxLength(100);

        builder.Property(e => e.Total).HasPrecision(18, 2);

        builder.HasOne(e => e.FromWarehouse)
            .WithMany()
            .HasForeignKey(e => e.FromWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ToWarehouse)
            .WithMany()
            .HasForeignKey(e => e.ToWarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.Number).IsUnique(false);
        builder.HasIndex(e => e.TransferDate);
        builder.HasIndex(e => e.Status);
    }
}

