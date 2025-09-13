using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// انتقال بین صندوق‌ها
/// </summary>
public class CashBoxTransfer : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه صندوق مبدا
    /// </summary>
    public Guid SourceCashBoxId { get; set; }

    /// <summary>
    /// شناسه صندوق مقصد
    /// </summary>
    public Guid TargetCashBoxId { get; set; }

    /// <summary>
    /// تاریخ انتقال
    /// </summary>
    public DateTime TransferDate { get; set; }

    /// <summary>
    /// مبلغ انتقال
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// مبلغ به ارز اصلی
    /// </summary>
    public decimal? AmountInBaseCurrency { get; set; }

    /// <summary>
    /// شماره مرجع
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// وضعیت انتقال
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// شناسه کاربر تاییدکننده
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// تاریخ تایید
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// صندوق مبدا
    /// </summary>
    public Treasury.CashBox SourceCashBox { get; set; } = null!;

    /// <summary>
    /// صندوق مقصد
    /// </summary>
    public Treasury.CashBox TargetCashBox { get; set; } = null!;

    /// <summary>
    /// کاربر ایجادکننده
    /// </summary>
    public Users.User? CreatedByUser { get; set; }

    /// <summary>
    /// کاربر تاییدکننده
    /// </summary>
    public Users.User? ApprovedByUser { get; set; }
}

/// <summary>
/// پیکربندی موجودیت انتقال بین صندوق‌ها
/// Cash Box Transfer entity configuration
/// </summary>
public class CashBoxTransferConfiguration : IEntityTypeConfiguration<CashBoxTransfer>
{
    public void Configure(EntityTypeBuilder<CashBoxTransfer> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.ReferenceNumber).HasMaxLength(100);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.Amount).HasPrecision(18, 2);
        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        builder.Property(e => e.AmountInBaseCurrency).HasPrecision(18, 2);

        // Relationships are configured in CashBoxConfiguration to avoid circular references

        builder.HasIndex(e => e.TransferDate);
        builder.HasIndex(e => e.Status);
        builder.HasIndex(e => e.SourceCashBoxId);
        builder.HasIndex(e => e.TargetCashBoxId);
    }
}
