namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// موجودیت ردیف دفتر کل (General Ledger)
/// General ledger entry row entity
/// </summary>
public class GeneralLedgerEntry : BaseEntity
{
    /// <summary>
    /// شناسه سند (Voucher/Journal)
    /// Voucher id
    /// </summary>
    public Guid VoucherId { get; set; }

    /// <summary>
    /// تاریخ سند
    /// Voucher date
    /// </summary>
    public DateTime VoucherDate { get; set; }

    /// <summary>
    /// شماره سند
    /// Voucher number
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// شماره ردیف
    /// Line number
    /// </summary>
    public int? LineNo { get; set; }

    /// <summary>
    /// شناسه حساب
    /// Account id
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// کد حساب
    /// Account code
    /// </summary>
    public string AccountCode { get; set; } = string.Empty;

    /// <summary>
    /// نام حساب
    /// Account name
    /// </summary>
    public string AccountName { get; set; } = string.Empty;

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
    /// وضعیت سند
    /// Voucher status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// نوع سند
    /// Voucher type
    /// </summary>
    public string Type { get; set; } = string.Empty;
    public DateTime TransactionDate { get; set; }
    public int DebitAmount { get; set; }
    public int CreditAmount { get; set; }

    /// <summary>
    /// حساب مرتبط با ردیف دفتر کل
    /// Related account
    /// </summary>
    public Account? Account { get; set; }

    /// <summary>
    /// سند/ثبت مرتبط با ردیف دفتر کل
    /// Related journal voucher
    /// </summary>
    public JournalVoucher? Voucher { get; set; }
}

/// <summary>
/// پیکربندی موجودیت ردیف دفتر کل
/// General Ledger Entry entity configuration
/// </summary>
public class GeneralLedgerEntryConfiguration : IEntityTypeConfiguration<GeneralLedgerEntry>
{
    public void Configure(EntityTypeBuilder<GeneralLedgerEntry> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Number).HasMaxLength(100);
        builder.Property(e => e.AccountCode).IsRequired().HasMaxLength(50);
        builder.Property(e => e.AccountName).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Status).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Type).IsRequired().HasMaxLength(50);

        builder.Property(e => e.Debit).HasPrecision(18, 2);
        builder.Property(e => e.Credit).HasPrecision(18, 2);
        builder.Property(e => e.DebitAmount).HasPrecision(18, 2);
        builder.Property(e => e.CreditAmount).HasPrecision(18, 2);

        builder.HasOne(e => e.Account)
            .WithMany()
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Voucher)
            .WithMany()
            .HasForeignKey(e => e.VoucherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.VoucherId);
        builder.HasIndex(e => e.VoucherDate);
        builder.HasIndex(e => e.AccountId);
        builder.HasIndex(e => e.TransactionDate);
    }
}

