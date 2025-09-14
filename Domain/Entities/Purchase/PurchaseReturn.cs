using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Purchase;

/// <summary>
/// برگشت خرید
/// Purchase Return
/// </summary>
public class PurchaseReturn : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// شماره برگشت
    /// Return number
    /// </summary>
    public string ReturnNumber { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ برگشت
    /// Return date
    /// </summary>
    public DateTime ReturnDate { get; set; }

    /// <summary>
    /// شناسه تامین‌کننده
    /// Vendor ID
    /// </summary>
    public Guid VendorId { get; set; }

    /// <summary>
    /// شناسه انبار
    /// Warehouse ID
    /// </summary>
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// شناسه رسید خرید
    /// Purchase receipt ID
    /// </summary>
    public Guid? PurchaseReceiptId { get; set; }

    /// <summary>
    /// وضعیت
    /// Status
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// مبلغ کل
    /// Total amount
    /// </summary>
    public decimal TotalAmount { get; set; } = 0;

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// Exchange rate
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// دلیل برگشت
    /// Return reason
    /// </summary>
    public string ReturnReason { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// تامین‌کننده مرتبط
    /// Related vendor
    /// </summary>
    public Accounting.ApVendor Vendor { get; set; } = null!;

    /// <summary>
    /// انبار مرتبط
    /// Related warehouse
    /// </summary>
    public Inventories.Warehouse Warehouse { get; set; } = null!;

    /// <summary>
    /// رسید خرید مرتبط
    /// Related purchase receipt
    /// </summary>
    public PurchaseReceipt? PurchaseReceipt { get; set; }

    /// <summary>
    /// خطوط برگشت
    /// Return lines
    /// </summary>
    public ICollection<PurchaseReturnLine> Lines { get; set; } = new List<PurchaseReturnLine>();
}

/// <summary>
/// پیکربندی موجودیت برگشت خرید
/// Purchase Return entity configuration
/// </summary>
public class PurchaseReturnConfiguration : IEntityTypeConfiguration<PurchaseReturn>
{
    public void Configure(EntityTypeBuilder<PurchaseReturn> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.ReturnNumber).HasMaxLength(100);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Description).HasMaxLength(1000);

        // Configure decimal properties with precision
        builder.Property(e => e.TotalAmount).HasPrecision(18, 2);
        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);

        builder.HasIndex(e => e.ReturnNumber).IsUnique(false);
        builder.HasIndex(e => e.VendorId);
        builder.HasIndex(e => e.WarehouseId);
        builder.HasIndex(e => e.Status);
    }
}
