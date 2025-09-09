using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class InventoryIssueNote : BaseEntity, IAggregateRoot
{
    public Guid WarehouseId { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.UtcNow;
    public string Currency { get; set; } = "IRR";
    public string Status { get; set; } = "draft"; // draft|posted
    public string? Number { get; set; }
    public decimal? Total { get; set; }

    // Navigation
    public Warehouse Warehouse { get; set; } = null!;
    public ICollection<InventoryIssueLine> Lines { get; set; } = new List<InventoryIssueLine>();
}

/// <summary>
/// پیکربندی موجودیت یادداشت خروج موجودی
/// Inventory Issue Note entity configuration
/// </summary>
public class InventoryIssueNoteConfiguration : IEntityTypeConfiguration<InventoryIssueNote>
{
    public void Configure(EntityTypeBuilder<InventoryIssueNote> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Number).HasMaxLength(100);

        builder.Property(e => e.Total).HasPrecision(18, 2);

        builder.HasOne(e => e.Warehouse)
            .WithMany()
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.Number).IsUnique(false);
        builder.HasIndex(e => e.IssueDate);
        builder.HasIndex(e => e.Status);
    }
}

