using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Accounting;
using Dinawin.Erp.Domain.Entities.FixedAssets;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Treasury;

/// <summary>
/// سند استهلاک دارایی ثابت
/// Fixed Asset Depreciation Entry
/// </summary>
public class FaDepreciationEntry : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه دارایی ثابت
    /// Fixed Asset ID
    /// </summary>
    public Guid FaAssetId { get; set; }

    /// <summary>
    /// شناسه دسته بندی دارایی
    /// Asset Category ID
    /// </summary>
    public Guid FaCategoryId { get; set; }

    /// <summary>
    /// شناسه دوره استهلاک
    /// Depreciation Run ID
    /// </summary>
    public Guid FaDepreciationRunId { get; set; }

    /// <summary>
    /// تاریخ استهلاک
    /// Depreciation Date
    /// </summary>
    public DateTime DepreciationDate { get; set; }

    /// <summary>
    /// شماره دوره
    /// Period Number
    /// </summary>
    public int PeriodNumber { get; set; }

    /// <summary>
    /// مبلغ استهلاک
    /// Depreciation Amount
    /// </summary>
    public decimal DepreciationAmount { get; set; }

    /// <summary>
    /// استهلاک انباشته
    /// Accumulated Depreciation
    /// </summary>
    public decimal AccumulatedDepreciation { get; set; }

    /// <summary>
    /// ارزش دفتری
    /// Book Value
    /// </summary>
    public decimal BookValue { get; set; }

    /// <summary>
    /// شناسه حساب استهلاک
    /// Depreciation Account ID
    /// </summary>
    public Guid? DepreciationAccountId { get; set; }

    /// <summary>
    /// شناسه حساب استهلاک انباشته
    /// Accumulated Depreciation Account ID
    /// </summary>
    public Guid? AccumulatedDepreciationAccountId { get; set; }

    /// <summary>
    /// شناسه سند حسابداری
    /// Journal Voucher ID
    /// </summary>
    public Guid? JournalVoucherId { get; set; }

    /// <summary>
    /// وضعیت سند
    /// Entry Status
    /// </summary>
    public string EntryStatus { get; set; } = "draft";

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
    /// مبلغ استهلاک به ارز اصلی
    /// Depreciation Amount in Base Currency
    /// </summary>
    public decimal DepreciationAmountBase { get; set; }

    /// <summary>
    /// استهلاک انباشته به ارز اصلی
    /// Accumulated Depreciation in Base Currency
    /// </summary>
    public decimal AccumulatedDepreciationBase { get; set; }

    /// <summary>
    /// ارزش دفتری به ارز اصلی
    /// Book Value in Base Currency
    /// </summary>
    public decimal BookValueBase { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// دارایی ثابت
    /// Fixed Asset
    /// </summary>
    public virtual FaAsset? FaAsset { get; set; }

    /// <summary>
    /// دسته بندی دارایی
    /// Asset Category
    /// </summary>
    public virtual FaCategory? FaCategory { get; set; }

    /// <summary>
    /// دوره استهلاک
    /// Depreciation Run
    /// </summary>
    public virtual FaDepreciationRun? FaDepreciationRun { get; set; }

    /// <summary>
    /// حساب استهلاک
    /// Depreciation Account
    /// </summary>
    public virtual Account? DepreciationAccount { get; set; }

    /// <summary>
    /// حساب استهلاک انباشته
    /// Accumulated Depreciation Account
    /// </summary>
    public virtual Account? AccumulatedDepreciationAccount { get; set; }

    /// <summary>
    /// سند حسابداری
    /// Journal Voucher
    /// </summary>
    public virtual AccJournalVoucher? JournalVoucher { get; set; }

    /// <summary>
    /// کاربر تایید کننده
    /// Approved By User
    /// </summary>
    public virtual User? ApprovedByUser { get; set; }
}

/// <summary>
/// پیکربندی موجودیت سند استهلاک دارایی ثابت
/// Fixed Asset Depreciation Entry entity configuration
/// </summary>
public class FaDepreciationEntryConfiguration : IEntityTypeConfiguration<FaDepreciationEntry>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<FaDepreciationEntry> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.DepreciationAmount)
            .HasPrecision(18, 2);

        builder.Property(e => e.AccumulatedDepreciation)
            .HasPrecision(18, 2);

        builder.Property(e => e.BookValue)
            .HasPrecision(18, 2);

        builder.Property(e => e.DepreciationAmountBase)
            .HasPrecision(18, 2);

        builder.Property(e => e.AccumulatedDepreciationBase)
            .HasPrecision(18, 2);

        builder.Property(e => e.BookValueBase)
            .HasPrecision(18, 2);

        builder.Property(e => e.Currency)
            .HasMaxLength(10);

        builder.Property(e => e.ExchangeRate)
            .HasPrecision(18, 6);

        builder.Property(e => e.EntryStatus)
            .HasMaxLength(50);

        builder.HasOne(e => e.FaAsset)
            .WithMany()
            .HasForeignKey(e => e.FaAssetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.FaCategory)
            .WithMany()
            .HasForeignKey(e => e.FaCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.FaDepreciationRun)
            .WithMany()
            .HasForeignKey(e => e.FaDepreciationRunId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.DepreciationAccount)
            .WithMany()
            .HasForeignKey(e => e.DepreciationAccountId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.AccumulatedDepreciationAccount)
            .WithMany()
            .HasForeignKey(e => e.AccumulatedDepreciationAccountId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.JournalVoucher)
            .WithMany()
            .HasForeignKey(e => e.JournalVoucherId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.ApprovedByUser)
            .WithMany()
            .HasForeignKey(e => e.ApprovedByUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => new { e.FaAssetId, e.PeriodNumber })
            .IsUnique();

        builder.HasIndex(e => e.FaDepreciationRunId);
    }
}
