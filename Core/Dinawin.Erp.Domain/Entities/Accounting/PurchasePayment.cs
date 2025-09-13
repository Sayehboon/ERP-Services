using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// پرداخت خرید
/// </summary>
public class PurchasePayment : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه سفارش خرید
    /// </summary>
    public Guid PurchaseOrderId { get; set; }

    /// <summary>
    /// شناسه صندوق نقدی
    /// </summary>
    public Guid? CashBoxId { get; set; }

    /// <summary>
    /// شناسه حساب بانکی
    /// </summary>
    public Guid? BankAccountId { get; set; }

    /// <summary>
    /// تاریخ پرداخت
    /// </summary>
    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// مبلغ پرداخت
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// مبلغ به ارز اصلی
    /// </summary>
    public decimal? AmountInBaseCurrency { get; set; }

    /// <summary>
    /// روش پرداخت
    /// </summary>
    public string PaymentMethod { get; set; } = string.Empty;

    /// <summary>
    /// شماره مرجع
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// شماره چک (در صورت پرداخت با چک)
    /// </summary>
    public string? CheckNumber { get; set; }

    /// <summary>
    /// تاریخ سررسید چک
    /// </summary>
    public DateTime? CheckDueDate { get; set; }

    /// <summary>
    /// وضعیت پرداخت
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// شناسه کاربر تاییدکننده
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// تاریخ تایید
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// سفارش خرید مرتبط
    /// </summary>
    public Purchase.PurchaseOrder PurchaseOrder { get; set; } = null!;

    /// <summary>
    /// صندوق نقدی مرتبط
    /// </summary>
    public Treasury.CashBox? CashBox { get; set; }

    /// <summary>
    /// حساب بانکی مرتبط
    /// </summary>
    public Treasury.BankAccount? BankAccount { get; set; }

    /// <summary>
    /// کاربر ایجادکننده
    /// </summary>
    public Users.User? CreatedByUser { get; set; }

    /// <summary>
    /// کاربر تاییدکننده
    /// </summary>
    public Users.User? ApprovedByUser { get; set; }
}

/// <summary>
/// پیکربندی موجودیت پرداخت خرید
/// Purchase Payment entity configuration
/// </summary>
public class PurchasePaymentConfiguration : IEntityTypeConfiguration<PurchasePayment>
{
    public void Configure(EntityTypeBuilder<PurchasePayment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.PaymentMethod).IsRequired().HasMaxLength(50);
        builder.Property(e => e.ReferenceNumber).HasMaxLength(100);
        builder.Property(e => e.CheckNumber).HasMaxLength(100);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.Amount).HasPrecision(18, 2);
        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        builder.Property(e => e.AmountInBaseCurrency).HasPrecision(18, 2);

        builder.HasOne(e => e.PurchaseOrder)
            .WithMany()
            .HasForeignKey(e => e.PurchaseOrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.CashBox)
            .WithMany()
            .HasForeignKey(e => e.CashBoxId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.BankAccount)
            .WithMany()
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasIndex(e => e.PurchaseOrderId);
        builder.HasIndex(e => e.PaymentDate);
        builder.HasIndex(e => e.Status);
    }
}
