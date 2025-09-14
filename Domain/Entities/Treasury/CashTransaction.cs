namespace Dinawin.Erp.Domain.Entities.Treasury;

using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// موجودیت تراکنش نقدی
/// Cash transaction entity
/// </summary>
public class CashTransaction : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه صندوق نقدی
    /// Cash box ID
    /// </summary>
    public Guid CashBoxId { get; set; }

    /// <summary>
    /// تاریخ تراکنش
    /// Transaction date
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// نوع تراکنش
    /// Transaction type
    /// </summary>
    public CashTransactionType Type { get; set; }

    /// <summary>
    /// مبلغ تراکنش
    /// Transaction amount
    /// </summary>
    public Money Amount { get; set; } = null!;

    /// <summary>
    /// شرح تراکنش
    /// Transaction description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// وضعیت تراکنش
    /// Transaction status
    /// </summary>
    public CashTransactionStatus Status { get; set; } = CashTransactionStatus.Draft;

    /// <summary>
    /// آیا پست شده است؟
    /// Is posted?
    /// </summary>
    public bool IsPosted { get; set; }

    /// <summary>
    /// صندوق نقدی
    /// Cash box
    /// </summary>
    public CashBox CashBox { get; set; } = null!;
    public Guid BankAccountId { get; set; }
    public string TransactionType { get; set; }
    public Guid? ReferenceId { get; set; }
    public string ReferenceType { get; set; }
}

/// <summary>
/// پیکربندی موجودیت تراکنش نقدی
/// Cash Transaction entity configuration
/// </summary>
public class CashTransactionConfiguration : IEntityTypeConfiguration<CashTransaction>
{
    public void Configure(EntityTypeBuilder<CashTransaction> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.TransactionType).HasMaxLength(50);
        builder.Property(e => e.ReferenceType).HasMaxLength(50);

        // Configure value objects
        builder.OwnsOne(e => e.Amount, amount =>
        {
            amount.Property(a => a.Amount).HasPrecision(18, 2);
            amount.Property(a => a.Currency).HasMaxLength(10);
        });

        builder.HasOne(e => e.CashBox)
            .WithMany(cb => cb.CashTransactions)
            .HasForeignKey(e => e.CashBoxId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.CashBoxId);
        builder.HasIndex(e => e.TransactionDate);
        builder.HasIndex(e => e.Type);
        builder.HasIndex(e => e.Status);
    }
}

/// <summary>
/// انواع تراکنش نقدی
/// Cash transaction types
/// </summary>
public enum CashTransactionType
{
    /// <summary>
    /// ورودی
    /// Inflow
    /// </summary>
    Inflow = 1,

    /// <summary>
    /// خروجی
    /// Outflow
    /// </summary>
    Outflow = 2
}

/// <summary>
/// وضعیت‌های تراکنش نقدی
/// Cash transaction statuses
/// </summary>
public enum CashTransactionStatus
{
    /// <summary>
    /// پیش‌نویس
    /// Draft
    /// </summary>
    Draft = 1,

    /// <summary>
    /// پست شده
    /// Posted
    /// </summary>
    Posted = 2,

    /// <summary>
    /// لغو شده
    /// Cancelled
    /// </summary>
    Cancelled = 3
}
