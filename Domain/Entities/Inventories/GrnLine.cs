using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class GrnLine : BaseEntity
{
    public Guid GrnId { get; set; }
    public int LineNo { get; set; }
    public Guid ProductId { get; set; }
    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal? TaxRate { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal Amount { get; set; }
    public DateTime? ExpiryDate { get; set; }

    // Navigation
    public GrnReceipt Grn { get; set; } = null!;
    public Products.Product Product { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت خط رسید کالا
/// GRN Line entity configuration
/// </summary>
public class GrnLineConfiguration : IEntityTypeConfiguration<GrnLine>
{
    public void Configure(EntityTypeBuilder<GrnLine> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Qty).HasPrecision(18, 4);
        builder.Property(e => e.UnitPrice).HasPrecision(18, 2);
        builder.Property(e => e.TaxRate).HasPrecision(5, 2);
        builder.Property(e => e.TaxAmount).HasPrecision(18, 2);
        builder.Property(e => e.Amount).HasPrecision(18, 2);

        builder.HasOne(e => e.Grn)
            .WithMany(g => g.Lines)
            .HasForeignKey(e => e.GrnId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Product)
            .WithMany()
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.GrnId);
        builder.HasIndex(e => e.LineNo);
    }
}

