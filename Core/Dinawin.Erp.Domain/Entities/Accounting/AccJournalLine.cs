using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// سطر سند حسابداری
/// Journal Line
/// </summary>
public class AccJournalLine : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه سند حسابداری
    /// Journal Voucher ID
    /// </summary>
    public Guid JournalVoucherId { get; set; }

    /// <summary>
    /// شناسه حساب
    /// Account ID
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// شرح سطر
    /// Line Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// مبلغ بدهکار
    /// Debit Amount
    /// </summary>
    public decimal DebitAmount { get; set; } = 0;

    /// <summary>
    /// مبلغ بستانکار
    /// Credit Amount
    /// </summary>
    public decimal CreditAmount { get; set; } = 0;

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// Exchange Rate
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// مبلغ بدهکار به ارز اصلی
    /// Debit Amount in Base Currency
    /// </summary>
    public decimal DebitAmountBase { get; set; } = 0;

    /// <summary>
    /// مبلغ بستانکار به ارز اصلی
    /// Credit Amount in Base Currency
    /// </summary>
    public decimal CreditAmountBase { get; set; } = 0;

    /// <summary>
    /// مرجع
    /// Reference
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// شماره سطر
    /// Line Number
    /// </summary>
    public int LineNumber { get; set; }

    /// <summary>
    /// شناسه بعد 1
    /// Dimension 1 ID
    /// </summary>
    public Guid? Dimension1Id { get; set; }

    /// <summary>
    /// شناسه بعد 2
    /// Dimension 2 ID
    /// </summary>
    public Guid? Dimension2Id { get; set; }

    /// <summary>
    /// شناسه بعد 3
    /// Dimension 3 ID
    /// </summary>
    public Guid? Dimension3Id { get; set; }

    /// <summary>
    /// شناسه بعد 4
    /// Dimension 4 ID
    /// </summary>
    public Guid? Dimension4Id { get; set; }

    /// <summary>
    /// شناسه بعد 5
    /// Dimension 5 ID
    /// </summary>
    public Guid? Dimension5Id { get; set; }

    /// <summary>
    /// مقدار بعد 1
    /// Dimension 1 Value ID
    /// </summary>
    public Guid? Dimension1ValueId { get; set; }

    /// <summary>
    /// مقدار بعد 2
    /// Dimension 2 Value ID
    /// </summary>
    public Guid? Dimension2ValueId { get; set; }

    /// <summary>
    /// مقدار بعد 3
    /// Dimension 3 Value ID
    /// </summary>
    public Guid? Dimension3ValueId { get; set; }

    /// <summary>
    /// مقدار بعد 4
    /// Dimension 4 Value ID
    /// </summary>
    public Guid? Dimension4ValueId { get; set; }

    /// <summary>
    /// مقدار بعد 5
    /// Dimension 5 Value ID
    /// </summary>
    public Guid? Dimension5ValueId { get; set; }

    // Navigation Properties
    /// <summary>
    /// سند حسابداری
    /// Journal Voucher
    /// </summary>
    public virtual AccJournalVoucher? JournalVoucher { get; set; }

    /// <summary>
    /// حساب
    /// Account
    /// </summary>
    public virtual Account? Account { get; set; }

    /// <summary>
    /// بعد 1
    /// Dimension 1
    /// </summary>
    public virtual AccDimension? Dimension1 { get; set; }

    /// <summary>
    /// بعد 2
    /// Dimension 2
    /// </summary>
    public virtual AccDimension? Dimension2 { get; set; }

    /// <summary>
    /// بعد 3
    /// Dimension 3
    /// </summary>
    public virtual AccDimension? Dimension3 { get; set; }

    /// <summary>
    /// بعد 4
    /// Dimension 4
    /// </summary>
    public virtual AccDimension? Dimension4 { get; set; }

    /// <summary>
    /// بعد 5
    /// Dimension 5
    /// </summary>
    public virtual AccDimension? Dimension5 { get; set; }

    /// <summary>
    /// مقدار بعد 1
    /// Dimension 1 Value
    /// </summary>
    public virtual AccDimensionValue? Dimension1Value { get; set; }

    /// <summary>
    /// مقدار بعد 2
    /// Dimension 2 Value
    /// </summary>
    public virtual AccDimensionValue? Dimension2Value { get; set; }

    /// <summary>
    /// مقدار بعد 3
    /// Dimension 3 Value
    /// </summary>
    public virtual AccDimensionValue? Dimension3Value { get; set; }

    /// <summary>
    /// مقدار بعد 4
    /// Dimension 4 Value
    /// </summary>
    public virtual AccDimensionValue? Dimension4Value { get; set; }

    /// <summary>
    /// مقدار بعد 5
    /// Dimension 5 Value
    /// </summary>
    public virtual AccDimensionValue? Dimension5Value { get; set; }
}

/// <summary>
/// پیکربندی موجودیت سطر سند حسابداری
/// Journal Line entity configuration
/// </summary>
public class AccJournalLineConfiguration : IEntityTypeConfiguration<AccJournalLine>
{
    public void Configure(EntityTypeBuilder<AccJournalLine> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Reference).HasMaxLength(200);

        builder.Property(e => e.DebitAmount).HasPrecision(18, 2);
        builder.Property(e => e.CreditAmount).HasPrecision(18, 2);
        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        builder.Property(e => e.DebitAmountBase).HasPrecision(18, 2);
        builder.Property(e => e.CreditAmountBase).HasPrecision(18, 2);

        builder.HasOne(e => e.JournalVoucher)
            .WithMany(jv => jv.JournalLines)
            .HasForeignKey(e => e.JournalVoucherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Account)
            .WithMany()
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.JournalVoucherId);
        builder.HasIndex(e => e.AccountId);
        builder.HasIndex(e => e.LineNumber);
    }
}
