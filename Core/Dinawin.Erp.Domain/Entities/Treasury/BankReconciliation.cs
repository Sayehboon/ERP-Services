using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Treasury;

/// <summary>
/// تطبیق بانکی
/// Bank Reconciliation
/// </summary>
public class BankReconciliation : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه حساب بانکی
    /// Bank account ID
    /// </summary>
    public Guid BankAccountId { get; set; }

    /// <summary>
    /// تاریخ تطبیق
    /// Reconciliation date
    /// </summary>
    public DateTime ReconciliationDate { get; set; }

    /// <summary>
    /// مانده دفتری
    /// Book balance
    /// </summary>
    public decimal BookBalance { get; set; }

    /// <summary>
    /// مانده بانکی
    /// Bank balance
    /// </summary>
    public decimal BankBalance { get; set; }

    /// <summary>
    /// اختلاف
    /// Difference
    /// </summary>
    public decimal Difference { get; set; }

    /// <summary>
    /// وضعیت
    /// Status
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// حساب بانکی مرتبط
    /// Related bank account
    /// </summary>
    public BankAccount BankAccount { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت تطبیق بانکی
/// Bank Reconciliation entity configuration
/// </summary>
public class BankReconciliationConfiguration : IEntityTypeConfiguration<BankReconciliation>
{
    public void Configure(EntityTypeBuilder<BankReconciliation> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.BookBalance).HasColumnType("decimal(18,2)");
        builder.Property(e => e.BankBalance).HasColumnType("decimal(18,2)");
        builder.Property(e => e.Difference).HasColumnType("decimal(18,2)");

        builder.HasOne(e => e.BankAccount)
            .WithMany()
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.BankAccountId);
        builder.HasIndex(e => e.ReconciliationDate);
        builder.HasIndex(e => e.Status);
    }
}
