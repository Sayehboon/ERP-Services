using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Treasury;

/// <summary>
/// تراکنش بانکی
/// Bank Transaction
/// </summary>
public class BankTransaction : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه حساب بانکی
    /// Bank account ID
    /// </summary>
    public Guid BankAccountId { get; set; }

    /// <summary>
    /// تاریخ تراکنش
    /// Transaction date
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// نوع تراکنش
    /// Transaction type
    /// </summary>
    public string TransactionType { get; set; } = string.Empty;

    /// <summary>
    /// مبلغ
    /// Amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// Exchange rate
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// مبلغ به ارز اصلی
    /// Amount in base currency
    /// </summary>
    public decimal? AmountInBaseCurrency { get; set; }

    /// <summary>
    /// شماره مرجع
    /// Reference number
    /// </summary>
    public string ReferenceNumber { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// وضعیت
    /// Status
    /// </summary>
    public string Status { get; set; } = "pending";

    /// <summary>
    /// مانده قبل از تراکنش
    /// Balance before transaction
    /// </summary>
    public decimal? BalanceBefore { get; set; }

    /// <summary>
    /// مانده بعد از تراکنش
    /// Balance after transaction
    /// </summary>
    public decimal? BalanceAfter { get; set; }

    // Navigation Properties
    /// <summary>
    /// حساب بانکی مرتبط
    /// Related bank account
    /// </summary>
    public BankAccount BankAccount { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت تراکنش بانکی
/// Bank Transaction entity configuration
/// </summary>
public class BankTransactionConfiguration : IEntityTypeConfiguration<BankTransaction>
{
    public void Configure(EntityTypeBuilder<BankTransaction> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.TransactionType).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.ReferenceNumber).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Status).HasMaxLength(50);

        builder.Property(e => e.Amount).HasPrecision(18, 2);
        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        builder.Property(e => e.AmountInBaseCurrency).HasPrecision(18, 2);
        builder.Property(e => e.BalanceBefore).HasPrecision(18, 2);
        builder.Property(e => e.BalanceAfter).HasPrecision(18, 2);

        builder.HasOne(e => e.BankAccount)
            .WithMany()
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.BankAccountId);
        builder.HasIndex(e => e.TransactionDate);
        builder.HasIndex(e => e.TransactionType);
        builder.HasIndex(e => e.ReferenceNumber);
    }
}
