using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// دریافت حساب‌های دریافتنی
/// Accounts Receivable Receipt
/// </summary>
public class ArReceipt : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// شناسه مشتری
    /// Customer ID
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// تاریخ دریافت
    /// Receipt date
    /// </summary>
    public DateTime ReceiptDate { get; set; }

    /// <summary>
    /// روش پرداخت
    /// Payment method
    /// </summary>
    public string Method { get; set; }

    /// <summary>
    /// شناسه حساب بانکی
    /// Bank account ID
    /// </summary>
    public Guid? BankAccountId { get; set; }

    /// <summary>
    /// شناسه صندوق نقدی
    /// Cash box ID
    /// </summary>
    public Guid? CashBoxId { get; set; }

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// Exchange rate
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// مبلغ
    /// Amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// وضعیت
    /// Status
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// پست شده؟
    /// Is posted?
    /// </summary>
    public bool Posted { get; set; } = false;

    /// <summary>
    /// تاریخ پست
    /// Posted at
    /// </summary>
    public DateTime? PostedAt { get; set; }

    // Navigation Properties
    /// <summary>
    /// مشتری مرتبط
    /// Related customer
    /// </summary>
    public ArCustomer Customer { get; set; } = null!;

    /// <summary>
    /// حساب بانکی مرتبط
    /// Related bank account
    /// </summary>
    public Treasury.BankAccount? BankAccount { get; set; }

    /// <summary>
    /// صندوق نقدی مرتبط
    /// Related cash box
    /// </summary>
    public Treasury.CashBox? CashBox { get; set; }

    /// <summary>
    /// تسویه‌های دریافت
    /// Receipt settlements
    /// </summary>
    public ICollection<ArSettlement> Settlements { get; set; } = new List<ArSettlement>();
}

/// <summary>
/// پیکربندی موجودیت دریافت حساب‌های دریافتنی
/// Accounts Receivable Receipt entity configuration
/// </summary>
public class ArReceiptConfiguration : IEntityTypeConfiguration<ArReceipt>
{
    public void Configure(EntityTypeBuilder<ArReceipt> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Method).HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Status).HasMaxLength(50);

        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        builder.Property(e => e.Amount).HasPrecision(18, 2);

        builder.HasOne(e => e.Customer)
            .WithMany(c => c.Receipts)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.BankAccount)
            .WithMany()
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.CashBox)
            .WithMany()
            .HasForeignKey(e => e.CashBoxId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(e => e.ReceiptDate);
        builder.HasIndex(e => e.CustomerId);
        builder.HasIndex(e => e.Status);
    }
}
