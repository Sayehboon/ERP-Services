using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// موجودی افتتاحیه
/// Opening Balance
/// </summary>
public class AccOpeningBalance : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه حساب
    /// Account ID
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// شناسه دوره مالی
    /// Fiscal Period ID
    /// </summary>
    public Guid FiscalPeriodId { get; set; }

    /// <summary>
    /// مانده بدهکار
    /// Debit Balance
    /// </summary>
    public decimal DebitBalance { get; set; } = 0;

    /// <summary>
    /// مانده بستانکار
    /// Credit Balance
    /// </summary>
    public decimal CreditBalance { get; set; } = 0;

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
    /// مانده بدهکار به ارز اصلی
    /// Debit Balance in Base Currency
    /// </summary>
    public decimal DebitBalanceBase { get; set; } = 0;

    /// <summary>
    /// مانده بستانکار به ارز اصلی
    /// Credit Balance in Base Currency
    /// </summary>
    public decimal CreditBalanceBase { get; set; } = 0;

    /// <summary>
    /// تاریخ ثبت
    /// Registration Date
    /// </summary>
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// شناسه کاربر ثبت کننده
    /// Registered By User ID
    /// </summary>
    public Guid RegisteredByUserId { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// آیا تایید شده است
    /// Is Approved
    /// </summary>
    public bool IsApproved { get; set; } = false;

    /// <summary>
    /// تاریخ تایید
    /// Approval Date
    /// </summary>
    public DateTime? ApprovalDate { get; set; }

    /// <summary>
    /// شناسه کاربر تایید کننده
    /// Approved By User ID
    /// </summary>
    public Guid? ApprovedByUserId { get; set; }

    // Navigation Properties
    /// <summary>
    /// حساب
    /// Account
    /// </summary>
    public virtual Account? Account { get; set; }

    /// <summary>
    /// دوره مالی
    /// Fiscal Period
    /// </summary>
    public virtual AccFiscalPeriod? FiscalPeriod { get; set; }

    /// <summary>
    /// کاربر ثبت کننده
    /// Registered By User
    /// </summary>
    public virtual User? RegisteredByUser { get; set; }

    /// <summary>
    /// کاربر تایید کننده
    /// Approved By User
    /// </summary>
    public virtual User? ApprovedByUser { get; set; }
}

/// <summary>
/// پیکربندی موجودیت موجودی افتتاحیه
/// Opening Balance entity configuration
/// </summary>
public class AccOpeningBalanceConfiguration : IEntityTypeConfiguration<AccOpeningBalance>
{
    public void Configure(EntityTypeBuilder<AccOpeningBalance> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.DebitBalance).HasPrecision(18, 2);
        builder.Property(e => e.CreditBalance).HasPrecision(18, 2);
        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        builder.Property(e => e.DebitBalanceBase).HasPrecision(18, 2);
        builder.Property(e => e.CreditBalanceBase).HasPrecision(18, 2);

        builder.HasOne(e => e.Account)
            .WithMany()
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.FiscalPeriod)
            .WithMany()
            .HasForeignKey(e => e.FiscalPeriodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.RegisteredByUser)
            .WithMany()
            .HasForeignKey(e => e.RegisteredByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.ApprovedByUser)
            .WithMany()
            .HasForeignKey(e => e.ApprovedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(e => new { e.AccountId, e.FiscalPeriodId }).IsUnique();
    }
}
