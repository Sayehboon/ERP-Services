using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// سند حسابداری
/// Journal Voucher
/// </summary>
public class AccJournalVoucher : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شماره سند
    /// Voucher Number
    /// </summary>
    public string VoucherNumber { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ سند
    /// Voucher Date
    /// </summary>
    public DateTime VoucherDate { get; set; }

    /// <summary>
    /// شناسه دوره مالی
    /// Fiscal Period ID
    /// </summary>
    public Guid FiscalPeriodId { get; set; }

    /// <summary>
    /// نوع سند
    /// Voucher Type
    /// </summary>
    public string VoucherType { get; set; } = string.Empty;

    /// <summary>
    /// شرح سند
    /// Voucher Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// مرجع
    /// Reference
    /// </summary>
    public string Reference { get; set; }

    /// <summary>
    /// وضعیت سند
    /// Voucher Status
    /// </summary>
    public string Status { get; set; } = "draft";

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

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// Created By User ID
    /// </summary>
    public Guid CreatedByUserId { get; set; }

    /// <summary>
    /// شناسه کاربر آخرین ویرایش
    /// Last Modified By User ID
    /// </summary>
    public Guid? LastModifiedByUserId { get; set; }

    /// <summary>
    /// مجموع بدهکار
    /// Total Debit
    /// </summary>
    public decimal TotalDebit { get; set; } = 0;

    /// <summary>
    /// مجموع بستانکار
    /// Total Credit
    /// </summary>
    public decimal TotalCredit { get; set; } = 0;

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
    /// مجموع بدهکار به ارز اصلی
    /// Total Debit in Base Currency
    /// </summary>
    public decimal TotalDebitBase { get; set; } = 0;

    /// <summary>
    /// مجموع بستانکار به ارز اصلی
    /// Total Credit in Base Currency
    /// </summary>
    public decimal TotalCreditBase { get; set; } = 0;

    // Navigation Properties
    /// <summary>
    /// دوره مالی
    /// Fiscal Period
    /// </summary>
    public virtual AccFiscalPeriod? FiscalPeriod { get; set; }

    /// <summary>
    /// کاربر تایید کننده
    /// Approved By User
    /// </summary>
    public virtual User? ApprovedByUser { get; set; }

    /// <summary>
    /// کاربر ایجاد کننده
    /// Created By User
    /// </summary>
    public virtual User? CreatedByUser { get; set; }

    /// <summary>
    /// کاربر آخرین ویرایش
    /// Last Modified By User
    /// </summary>
    public virtual User? LastModifiedByUser { get; set; }

    /// <summary>
    /// سطرهای سند
    /// Journal Lines
    /// </summary>
    public virtual ICollection<AccJournalLine> JournalLines { get; set; } = new List<AccJournalLine>();

    /// <summary>
    /// لاگ های تایید
    /// Approval Logs
    /// </summary>
    public virtual ICollection<AccJournalApprovalLog> ApprovalLogs { get; set; } = new List<AccJournalApprovalLog>();
}

/// <summary>
/// پیکربندی موجودیت سند حسابداری
/// Accounting Journal Voucher entity configuration
/// </summary>
public class AccJournalVoucherConfiguration : IEntityTypeConfiguration<AccJournalVoucher>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<AccJournalVoucher> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.VoucherNumber)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.VoucherType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Description)
            .HasMaxLength(1000);

        builder.Property(e => e.Reference)
            .HasMaxLength(200);

        builder.Property(e => e.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Currency)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(e => e.TotalDebit)
            .HasPrecision(18, 2);

        builder.Property(e => e.TotalCredit)
            .HasPrecision(18, 2);

        builder.Property(e => e.ExchangeRate)
            .HasPrecision(18, 6);

        builder.Property(e => e.TotalDebitBase)
            .HasPrecision(18, 2);

        builder.Property(e => e.TotalCreditBase)
            .HasPrecision(18, 2);

        builder.HasOne(e => e.FiscalPeriod)
            .WithMany()
            .HasForeignKey(e => e.FiscalPeriodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ApprovedByUser)
            .WithMany()
            .HasForeignKey(e => e.ApprovedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.CreatedByUser)
            .WithMany()
            .HasForeignKey(e => e.CreatedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.LastModifiedByUser)
            .WithMany()
            .HasForeignKey(e => e.LastModifiedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(e => e.JournalLines)
            .WithOne(e => e.JournalVoucher)
            .HasForeignKey(e => e.JournalVoucherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.ApprovalLogs)
            .WithOne(e => e.JournalVoucher)
            .HasForeignKey(e => e.JournalVoucherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.VoucherNumber)
            .IsUnique();

        builder.HasIndex(e => e.FiscalPeriodId);
        builder.HasIndex(e => e.VoucherDate);
        builder.HasIndex(e => e.Status);
    }
}
