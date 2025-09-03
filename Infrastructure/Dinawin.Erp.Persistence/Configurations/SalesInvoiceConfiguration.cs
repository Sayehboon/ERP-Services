using Dinawin.Erp.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

/// <summary>
/// پیکربندی EF برای فاکتور فروش
/// EF configuration for SalesInvoice
/// </summary>
public class SalesInvoiceConfiguration : IEntityTypeConfiguration<SalesInvoice>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    public void Configure(EntityTypeBuilder<SalesInvoice> builder)
    {
        builder.ToTable("SalesInvoices", schema: "AR");

        builder.Property(p => p.Number)
            .HasMaxLength(50);

        builder.Property(p => p.Status)
            .HasMaxLength(30)
            .HasDefaultValue("draft");

        builder.Property(p => p.InvoiceDate)
            .HasColumnType("date");

        builder.HasMany(p => p.LineItems)
            .WithOne()
            .HasForeignKey(l => l.SalesInvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.Number)
            .IsUnique(false)
            .HasDatabaseName("IX_SalesInvoices_Number");

        builder.HasIndex(p => new { p.CustomerId, p.InvoiceDate })
            .HasDatabaseName("IX_SalesInvoices_Customer_Date");
    }
}

/// <summary>
/// پیکربندی EF برای ردیف‌های فاکتور فروش
/// EF configuration for SalesInvoiceLine
/// </summary>
public class SalesInvoiceLineConfiguration : IEntityTypeConfiguration<SalesInvoiceLine>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    public void Configure(EntityTypeBuilder<SalesInvoiceLine> builder)
    {
        builder.ToTable("SalesInvoiceLines", schema: "AR");

        builder.Property(p => p.Quantity).HasPrecision(18, 3);
        builder.Property(p => p.UnitPrice).HasPrecision(18, 2);
        builder.Property(p => p.LineDiscount).HasPrecision(18, 2);
        builder.Property(p => p.LineTotal).HasPrecision(18, 2);

        builder.Property(p => p.TaxRate).HasPrecision(5, 2);
        builder.Property(p => p.TaxAmount).HasPrecision(18, 2);

        builder.Property(p => p.Description).HasMaxLength(500);

        builder.HasIndex(p => p.SalesInvoiceId)
            .HasDatabaseName("IX_SalesInvoiceLines_InvoiceId");
    }
}


