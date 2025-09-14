using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// موجودیت تراکنش حسابداری
/// Accounting Transaction entity
/// </summary>
public class Transaction : BaseEntity
{
    /// <summary>
    /// شماره تراکنش
    /// Transaction number
    /// </summary>
    public string TransactionNumber { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ تراکنش
    /// Transaction date
    /// </summary>
    public DateTime TransactionDate { get; set; }

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
    public string Description { get; set; }

    /// <summary>
    /// شماره مرجع
    /// Reference number
    /// </summary>
    public string ReferenceNumber { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>
    

    /// <summary>
    /// یادداشت‌های تراکنش
    /// Transaction notes
    /// </summary>
    public string Notes { get; set; }
}

/// <summary>
/// پیکربندی موجودیت تراکنش حسابداری
/// Accounting Transaction entity configuration
/// </summary>
public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.TransactionNumber).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Type).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.ReferenceNumber).HasMaxLength(100);
        builder.Property(e => e.Notes).HasMaxLength(2000);

        builder.Property(e => e.Amount).HasPrecision(18, 2);

        builder.HasIndex(e => e.TransactionNumber).IsUnique(false);
        builder.HasIndex(e => e.TransactionDate);
        builder.HasIndex(e => e.Type);
    }
}
