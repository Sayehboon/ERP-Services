using Dinawin.Erp.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

public class PurchaseBillConfiguration : IEntityTypeConfiguration<PurchaseBill>
{
    public void Configure(EntityTypeBuilder<PurchaseBill> builder)
    {
        builder.ToTable("PurchaseBills", "AP");
        builder.Property(p => p.Number).HasMaxLength(50);
        builder.Property(p => p.Status).HasMaxLength(30).HasDefaultValue("draft");
        builder.Property(p => p.BillDate).HasColumnType("date");
        builder.HasMany(p => p.LineItems).WithOne().HasForeignKey(l => l.PurchaseBillId).OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(p => new { p.VendorId, p.BillDate }).HasDatabaseName("IX_PurchaseBills_Vendor_Date");
    }
}

public class PurchaseBillLineConfiguration : IEntityTypeConfiguration<PurchaseBillLine>
{
    public void Configure(EntityTypeBuilder<PurchaseBillLine> builder)
    {
        builder.ToTable("PurchaseBillLines", "AP");
        builder.Property(p => p.Quantity).HasPrecision(18, 3);
        builder.Property(p => p.UnitPrice).HasPrecision(18, 2);
        builder.Property(p => p.LineDiscount).HasPrecision(18, 2);
        builder.Property(p => p.TaxRate).HasPrecision(5, 2);
        builder.Property(p => p.TaxAmount).HasPrecision(18, 2);
        builder.Property(p => p.LineTotal).HasPrecision(18, 2);
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.HasIndex(p => p.PurchaseBillId).HasDatabaseName("IX_PurchaseBillLines_BillId");
    }
}


