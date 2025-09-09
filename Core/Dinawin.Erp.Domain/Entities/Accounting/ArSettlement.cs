using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// تسویه حساب‌های دریافتنی
/// Accounts Receivable Settlement
/// </summary>
public class ArSettlement : BaseEntity
{
    /// <summary>
    /// شناسه فاکتور
    /// Invoice ID
    /// </summary>
    public Guid InvoiceId { get; set; }

    /// <summary>
    /// شناسه دریافت
    /// Receipt ID
    /// </summary>
    public Guid ReceiptId { get; set; }

    /// <summary>
    /// مبلغ تسویه
    /// Settlement amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// تاریخ تسویه
    /// Settled at
    /// </summary>
    public DateTime SettledAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    /// <summary>
    /// فاکتور مرتبط
    /// Related invoice
    /// </summary>
    public ArInvoice Invoice { get; set; } = null!;

    /// <summary>
    /// دریافت مرتبط
    /// Related receipt
    /// </summary>
    public ArReceipt Receipt { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت تسویه حساب‌های دریافتنی
/// Accounts Receivable Settlement entity configuration
/// </summary>
public class ArSettlementConfiguration : IEntityTypeConfiguration<ArSettlement>
{
    public void Configure(EntityTypeBuilder<ArSettlement> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Amount).HasColumnType("decimal(18,2)");

        builder.HasOne(e => e.Invoice)
            .WithMany(i => i.Settlements)
            .HasForeignKey(e => e.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Receipt)
            .WithMany(r => r.Settlements)
            .HasForeignKey(e => e.ReceiptId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.InvoiceId);
        builder.HasIndex(e => e.ReceiptId);
        builder.HasIndex(e => e.SettledAt);
    }
}
