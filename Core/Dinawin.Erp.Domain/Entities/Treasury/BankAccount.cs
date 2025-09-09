namespace Dinawin.Erp.Domain.Entities.Treasury;

using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// موجودیت حساب بانکی
/// Bank account entity
/// </summary>
public class BankAccount : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام حساب بانکی
    /// Bank account name
    /// </summary>
    public required string AccountName { get; set; }

    /// <summary>
    /// شماره IBAN
    /// IBAN number
    /// </summary>
    public string? Iban { get; set; }

    /// <summary>
    /// ارز حساب
    /// Account currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// شناسه حساب کنترل
    /// Control account ID
    /// </summary>
    public Guid? ControlAccountId { get; set; }

    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public string BusinessId { get; set; } = "default";

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// حساب کنترل
    /// Control account
    /// </summary>
    public Accounting.Account? ControlAccount { get; set; }
    public decimal CurrentBalance { get; set; }
    public string? BankName { get; set; }
    public string? AccountNumber { get; set; }
    public string? AccountType { get; set; }
    public decimal InitialBalance { get; set; }
    public string? BranchName { get; set; }
    public string? BranchCode { get; set; }
    public string? BranchAddress { get; set; }
    public string? BranchPhone { get; set; }
    public string? CardNumber { get; set; }
    public string? Notes { get; set; }
    public string? BankCode { get; set; }
    public string? AccountHolderName { get; set; }
    public string? Description { get; set; }

    /// <summary>
    /// پرداخت‌های فروش از این حساب
    /// Sale payments from this bank account
    /// </summary>
    public ICollection<Dinawin.Erp.Domain.Entities.Accounting.SalePayment> SalePayments { get; set; } = new List<Dinawin.Erp.Domain.Entities.Accounting.SalePayment>();

    /// <summary>
    /// پرداخت‌های خرید از این حساب
    /// Purchase payments from this bank account
    /// </summary>
    public ICollection<Dinawin.Erp.Domain.Entities.Accounting.PurchasePayment> PurchasePayments { get; set; } = new List<Dinawin.Erp.Domain.Entities.Accounting.PurchasePayment>();
}

/// <summary>
/// پیکربندی موجودیت حساب بانکی
/// Bank Account entity configuration
/// </summary>
public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.AccountName).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Iban).HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.BusinessId).HasMaxLength(100);
        builder.Property(e => e.BankName).HasMaxLength(200);
        builder.Property(e => e.AccountNumber).HasMaxLength(50);
        builder.Property(e => e.AccountType).HasMaxLength(50);
        builder.Property(e => e.BranchName).HasMaxLength(200);
        builder.Property(e => e.BranchCode).HasMaxLength(50);
        builder.Property(e => e.BranchAddress).HasMaxLength(500);
        builder.Property(e => e.BranchPhone).HasMaxLength(20);
        builder.Property(e => e.CardNumber).HasMaxLength(50);
        builder.Property(e => e.Notes).HasMaxLength(1000);
        builder.Property(e => e.BankCode).HasMaxLength(50);
        builder.Property(e => e.AccountHolderName).HasMaxLength(200);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.CurrentBalance).HasColumnType("decimal(18,2)");
        builder.Property(e => e.InitialBalance).HasColumnType("decimal(18,2)");

        builder.HasOne(e => e.ControlAccount)
            .WithMany()
            .HasForeignKey(e => e.ControlAccountId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.Iban).IsUnique(false);
        builder.HasIndex(e => e.AccountNumber).IsUnique(false);
        builder.HasIndex(e => e.BusinessId);
    }
}
