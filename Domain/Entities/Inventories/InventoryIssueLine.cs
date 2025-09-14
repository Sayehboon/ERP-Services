using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class InventoryIssueLine : BaseEntity
{
    public Guid NoteId { get; set; }
    public int LineNo { get; set; }
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal? UnitCost { get; set; }
    public decimal? Amount { get; set; }
    public Guid? BinId { get; set; }

    // Navigation
    public InventoryIssueNote Note { get; set; } = null!;
    public Products.Product Product { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت خط یادداشت خروج موجودی
/// Inventory Issue Line entity configuration
/// </summary>
public class InventoryIssueLineConfiguration : IEntityTypeConfiguration<InventoryIssueLine>
{
    public void Configure(EntityTypeBuilder<InventoryIssueLine> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Quantity).HasPrecision(18, 4);
        builder.Property(e => e.UnitCost).HasPrecision(18, 2);
        builder.Property(e => e.Amount).HasPrecision(18, 2);

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

