using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Treasury;

/// <summary>
/// موجودیت تراکنش صندوق نقدی
/// Cash Box Transaction entity
/// </summary>
public class CashBoxTransaction : BaseEntity
{
    /// <summary>
    /// شناسه صندوق نقدی
    /// Cash box ID
    /// </summary>
    public Guid CashBoxId { get; set; }

    /// <summary>
    /// نوع تراکنش
    /// Transaction type
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// مبلغ تراکنش
    /// Transaction amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// ارز تراکنش
    /// Transaction currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// توضیحات تراکنش
    /// Transaction description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شماره مرجع
    /// Reference number
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// تاریخ تراکنش
    /// Transaction date
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// شناسه کاربر تاییدکننده
    /// Approved by user ID
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// یادداشت‌های تراکنش
    /// Transaction notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// صندوق نقدی مرتبط
    /// Related cash box
    /// </summary>
    public CashBox? CashBox { get; set; }

    /// <summary>
    /// کاربر ایجادکننده تراکنش
    /// Created by user
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Users.User? CreatedByUser { get; set; }

    /// <summary>
    /// کاربر تاییدکننده تراکنش
    /// Approved by user
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Users.User? ApprovedByUser { get; set; }
    public decimal? BalanceBefore { get; set; }
    public string Status { get; set; }
    public decimal? BalanceAfter { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public string TransactionType { get; set; }
    public decimal? ExchangeRate { get; set; }
    public decimal? AmountInBaseCurrency { get; set; }
}

/// <summary>
/// پیکربندی موجودیت تراکنش صندوق نقدی
/// Cash Box Transaction entity configuration
/// </summary>
public class CashBoxTransactionConfiguration : IEntityTypeConfiguration<CashBoxTransaction>
{
    public void Configure(EntityTypeBuilder<CashBoxTransaction> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Type).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.ReferenceNumber).HasMaxLength(100);
        builder.Property(e => e.Notes).HasMaxLength(2000);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.TransactionType).HasMaxLength(50);

        builder.Property(e => e.Amount).HasPrecision(18, 2);
        builder.Property(e => e.BalanceBefore).HasPrecision(18, 2);
        builder.Property(e => e.BalanceAfter).HasPrecision(18, 2);
        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        builder.Property(e => e.AmountInBaseCurrency).HasPrecision(18, 2);

        builder.HasOne(e => e.CashBox)
            .WithMany(cb => cb.BoxTransactions)
            .HasForeignKey(e => e.CashBoxId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.CashBoxId);
        builder.HasIndex(e => e.TransactionDate);
        builder.HasIndex(e => e.Type);
        builder.HasIndex(e => e.Status);
    }
}
