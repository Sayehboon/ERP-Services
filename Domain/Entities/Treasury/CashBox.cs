namespace Dinawin.Erp.Domain.Entities.Treasury;

using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// موجودیت صندوق نقدی
/// Cash box entity
/// </summary>
public class CashBox : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// نام صندوق
    /// Cash box name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// مکان صندوق
    /// Cash box location
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    /// شناسه حساب کنترل
    /// Control account ID
    /// </summary>
    public Guid? ControlAccountId { get; set; }

    /// <summary>
    /// وضعیت فعال بودن صندوق
    /// Cash box active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    /// <summary>
    /// کسب‌وکار مرتبط
    /// Related business
    /// </summary>
    public Users.Company? Business { get; set; }

    /// <summary>
    /// حساب کنترل مرتبط
    /// Related control account
    /// </summary>
    public Accounting.Account? ControlAccount { get; set; }

    /// <summary>
    /// تراکنش‌های نقدی این صندوق
    /// Cash transactions for this box
    /// </summary>
    public ICollection<CashTransaction> CashTransactions { get; set; } = new List<CashTransaction>();

    /// <summary>
    /// تراکنش‌های ساده صندوق
    /// Simple cash box transactions
    /// </summary>
    public ICollection<CashBoxTransaction> BoxTransactions { get; set; } = new List<CashBoxTransaction>();

    /// <summary>
    /// انتقال‌های خروجی از این صندوق
    /// Outgoing transfers from this cash box
    /// </summary>
    public ICollection<Dinawin.Erp.Domain.Entities.Accounting.CashBoxTransfer> OutgoingTransfers { get; set; } = new List<Dinawin.Erp.Domain.Entities.Accounting.CashBoxTransfer>();

    /// <summary>
    /// انتقال‌های ورودی به این صندوق
    /// Incoming transfers to this cash box
    /// </summary>
    public ICollection<Dinawin.Erp.Domain.Entities.Accounting.CashBoxTransfer> IncomingTransfers { get; set; } = new List<Dinawin.Erp.Domain.Entities.Accounting.CashBoxTransfer>();

    /// <summary>
    /// پرداخت‌های فروش از این صندوق
    /// Sale payments from this cash box
    /// </summary>
    public ICollection<Dinawin.Erp.Domain.Entities.Accounting.SalePayment> SalePayments { get; set; } = new List<Dinawin.Erp.Domain.Entities.Accounting.SalePayment>();

    /// <summary>
    /// پرداخت‌های خرید از این صندوق
    /// Purchase payments from this cash box
    /// </summary>
    public ICollection<Dinawin.Erp.Domain.Entities.Accounting.PurchasePayment> PurchasePayments { get; set; } = new List<Dinawin.Erp.Domain.Entities.Accounting.PurchasePayment>();
}

/// <summary>
/// پیکربندی موجودیت صندوق نقدی
/// Cash Box entity configuration
/// </summary>
public class CashBoxConfiguration : IEntityTypeConfiguration<CashBox>
{
    public void Configure(EntityTypeBuilder<CashBox> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Location).HasMaxLength(200);

        builder.HasOne(e => e.Business)
            .WithMany()
            .HasForeignKey(e => e.BusinessId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ControlAccount)
            .WithMany()
            .HasForeignKey(e => e.ControlAccountId)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure relationships with CashBoxTransfer
        builder.HasMany(e => e.OutgoingTransfers)
            .WithOne(t => t.SourceCashBox)
            .HasForeignKey(t => t.SourceCashBoxId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(e => e.IncomingTransfers)
            .WithOne(t => t.TargetCashBox)
            .HasForeignKey(t => t.TargetCashBoxId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.BusinessId);
    }
}
