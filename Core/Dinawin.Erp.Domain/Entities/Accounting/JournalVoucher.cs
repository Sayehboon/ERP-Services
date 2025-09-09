namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// موجودیت سند حسابداری
/// Journal voucher entity
/// </summary>
public class JournalVoucher : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شماره سند
    /// Voucher number
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// شماره ترتیبی
    /// Sequence number
    /// </summary>
    public int? SeqNo { get; set; }

    /// <summary>
    /// تاریخ سند
    /// Voucher date
    /// </summary>
    public DateTime VoucherDate { get; set; }

    /// <summary>
    /// نوع سند
    /// Voucher type
    /// </summary>
    public string Type { get; set; } = "JV"; // JV, SYS, OPEN, CLOSE, ADJ

    /// <summary>
    /// شرح سند
    /// Voucher description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// وضعیت سند
    /// Voucher status
    /// </summary>
    public string Status { get; set; } = "draft"; // draft, posted, void

    /// <summary>
    /// مرحله تایید
    /// Approval stage
    /// </summary>
    public int? ApprovalStage { get; set; }

    /// <summary>
    /// وضعیت تایید
    /// Approval status
    /// </summary>
    public string? ApprovalStatus { get; set; } // pending, approved, rejected, void

    /// <summary>
    /// شناسه سال مالی
    /// Fiscal year ID
    /// </summary>
    public Guid FiscalYearId { get; set; }

    /// <summary>
    /// شناسه دوره مالی
    /// Fiscal period ID
    /// </summary>
    public Guid FiscalPeriodId { get; set; }

    /// <summary>
    /// ردیف‌های سند
    /// Voucher lines
    /// </summary>
    public ICollection<JournalLine> Lines { get; set; } = new List<JournalLine>();

    /// <summary>
    /// سال مالی مرتبط
    /// Related fiscal year
    /// </summary>
    public FiscalYear? FiscalYear { get; set; }

    /// <summary>
    /// دوره مالی مرتبط
    /// Related fiscal period
    /// </summary>
    public FiscalPeriod? FiscalPeriod { get; set; }
}

/// <summary>
/// ردیف سند حسابداری
/// Journal line entity
/// </summary>
public class JournalLine : BaseEntity
{
    /// <summary>
    /// شناسه سند
    /// Voucher ID
    /// </summary>
    public Guid VoucherId { get; set; }

    /// <summary>
    /// شناسه حساب
    /// Account ID
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// شرح ردیف
    /// Line description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// مبلغ بدهکار
    /// Debit amount
    /// </summary>
    public decimal Debit { get; set; }

    /// <summary>
    /// مبلغ بستانکار
    /// Credit amount
    /// </summary>
    public decimal Credit { get; set; }

    /// <summary>
    /// سند مرتبط
    /// Related voucher
    /// </summary>
    public JournalVoucher? Voucher { get; set; }

    /// <summary>
    /// حساب مرتبط
    /// Related account
    /// </summary>
    public Account? Account { get; set; }
}

/// <summary>
/// پیکربندی موجودیت سند حسابداری
/// Journal Voucher entity configuration
/// </summary>
public class JournalVoucherConfiguration : IEntityTypeConfiguration<JournalVoucher>
{
    public void Configure(EntityTypeBuilder<JournalVoucher> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Number).HasMaxLength(100);
        builder.Property(e => e.Type).IsRequired().HasMaxLength(10);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Status).IsRequired().HasMaxLength(50);
        builder.Property(e => e.ApprovalStatus).HasMaxLength(50);

        builder.HasOne(e => e.FiscalYear)
            .WithMany()
            .HasForeignKey(e => e.FiscalYearId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.FiscalPeriod)
            .WithMany()
            .HasForeignKey(e => e.FiscalPeriodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.Number).IsUnique(false);
        builder.HasIndex(e => e.VoucherDate);
        builder.HasIndex(e => e.Status);
        builder.HasIndex(e => e.Type);
    }
}

/// <summary>
/// پیکربندی موجودیت ردیف سند حسابداری
/// Journal Line entity configuration
/// </summary>
public class JournalLineConfiguration : IEntityTypeConfiguration<JournalLine>
{
    public void Configure(EntityTypeBuilder<JournalLine> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.Debit).HasPrecision(18, 2);
        builder.Property(e => e.Credit).HasPrecision(18, 2);

        builder.HasOne(e => e.Voucher)
            .WithMany(v => v.Lines)
            .HasForeignKey(e => e.VoucherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Account)
            .WithMany()
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.VoucherId);
        builder.HasIndex(e => e.AccountId);
    }
}
