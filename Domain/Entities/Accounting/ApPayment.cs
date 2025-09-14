using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// پرداخت حساب‌های پرداختنی
/// Accounts Payable Payment
/// </summary>
public class ApPayment : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// شناسه تامین‌کننده
    /// Vendor ID
    /// </summary>
    public Guid VendorId { get; set; }

    /// <summary>
    /// تاریخ پرداخت
    /// Payment date
    /// </summary>
    public DateTime PaymentDate { get; set; }

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
    /// تامین‌کننده مرتبط
    /// Related vendor
    /// </summary>
    public ApVendor Vendor { get; set; } = null!;

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
    /// تسویه‌های پرداخت
    /// Payment settlements
    /// </summary>
    public ICollection<ApSettlement> Settlements { get; set; } = new List<ApSettlement>();
}

/// <summary>
/// پیکربندی موجودیت پرداخت حساب‌های پرداختنی
/// Accounts Payable Payment entity configuration
/// </summary>
public class ApPaymentConfiguration : IEntityTypeConfiguration<ApPayment>
{
    public void Configure(EntityTypeBuilder<ApPayment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Method).HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Status).HasMaxLength(50);

        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        builder.Property(e => e.Amount).HasPrecision(18, 2);

        builder.HasOne(e => e.Vendor)
            .WithMany(v => v.Payments)
            .HasForeignKey(e => e.VendorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.BankAccount)
            .WithMany()
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.CashBox)
            .WithMany()
            .HasForeignKey(e => e.CashBoxId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(e => e.PaymentDate);
        builder.HasIndex(e => e.VendorId);
        builder.HasIndex(e => e.Status);
    }
}
