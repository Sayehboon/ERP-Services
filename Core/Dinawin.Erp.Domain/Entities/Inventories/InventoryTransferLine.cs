using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class InventoryTransferLine : BaseEntity
{
    public Guid NoteId { get; set; }
    public int LineNo { get; set; }
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public Guid? FromBinId { get; set; }
    public Guid? ToBinId { get; set; }
    public decimal? Amount { get; set; }

    // Navigation
    public InventoryTransferNote Note { get; set; } = null!;
    public Products.Product Product { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت خط یادداشت انتقال موجودی
/// Inventory Transfer Line entity configuration
/// </summary>
public class InventoryTransferLineConfiguration : IEntityTypeConfiguration<InventoryTransferLine>
{
    public void Configure(EntityTypeBuilder<InventoryTransferLine> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Quantity).HasColumnType("decimal(18,4)");
        builder.Property(e => e.Amount).HasColumnType("decimal(18,2)");

        builder.HasOne(e => e.Note)
            .WithMany(n => n.Lines)
            .HasForeignKey(e => e.NoteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Product)
            .WithMany()
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.NoteId);
        builder.HasIndex(e => e.LineNo);
    }
}

