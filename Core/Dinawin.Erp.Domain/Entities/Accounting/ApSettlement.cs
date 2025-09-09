using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// تسویه حساب‌های پرداختنی
/// Accounts Payable Settlement
/// </summary>
public class ApSettlement : BaseEntity
{
    /// <summary>
    /// شناسه فاکتور
    /// Bill ID
    /// </summary>
    public Guid BillId { get; set; }

    /// <summary>
    /// شناسه پرداخت
    /// Payment ID
    /// </summary>
    public Guid PaymentId { get; set; }

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
    /// Related bill
    /// </summary>
    public ApBill Bill { get; set; } = null!;

    /// <summary>
    /// پرداخت مرتبط
    /// Related payment
    /// </summary>
    public ApPayment Payment { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت تسویه حساب‌های پرداختنی
/// Accounts Payable Settlement entity configuration
/// </summary>
public class ApSettlementConfiguration : IEntityTypeConfiguration<ApSettlement>
{
    public void Configure(EntityTypeBuilder<ApSettlement> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Amount).HasColumnType("decimal(18,2)");

        builder.HasOne(e => e.Bill)
            .WithMany(b => b.Settlements)
            .HasForeignKey(e => e.BillId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Payment)
            .WithMany(p => p.Settlements)
            .HasForeignKey(e => e.PaymentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.BillId);
        builder.HasIndex(e => e.PaymentId);
        builder.HasIndex(e => e.SettledAt);
    }
}
