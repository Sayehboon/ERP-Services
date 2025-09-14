using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Purchase;

/// <summary>
/// رسید خرید (GRN - Goods Receipt Note)
/// Purchase Receipt
/// </summary>
public class PurchaseReceipt : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// شماره رسید
    /// Receipt number
    /// </summary>
    public string ReceiptNumber { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ رسید
    /// Receipt date
    /// </summary>
    public DateTime ReceiptDate { get; set; }

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
    /// شناسه سفارش خرید
    /// Purchase order ID
    /// </summary>
    public Guid? PurchaseOrderId { get; set; }

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
    /// سفارش خرید مرتبط
    /// Related purchase order
    /// </summary>
    public PurchaseOrder? PurchaseOrder { get; set; }

    /// <summary>
    /// خطوط رسید
    /// Receipt lines
    /// </summary>
    public ICollection<PurchaseReceiptLine> Lines { get; set; } = new List<PurchaseReceiptLine>();
}

/// <summary>
/// پیکربندی موجودیت رسید خرید
/// Purchase Receipt entity configuration
/// </summary>
public class PurchaseReceiptConfiguration : IEntityTypeConfiguration<PurchaseReceipt>
{
    public void Configure(EntityTypeBuilder<PurchaseReceipt> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.ReceiptNumber).HasMaxLength(100);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Description).HasMaxLength(1000);

        // Configure decimal properties with precision
        builder.Property(e => e.TotalAmount).HasPrecision(18, 2);
        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);

        builder.HasIndex(e => e.ReceiptNumber).IsUnique(false);
        builder.HasIndex(e => e.VendorId);
        builder.HasIndex(e => e.WarehouseId);
        builder.HasIndex(e => e.Status);
    }
}
