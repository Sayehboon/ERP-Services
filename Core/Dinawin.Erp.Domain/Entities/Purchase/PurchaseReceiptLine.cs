using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Purchase;

/// <summary>
/// خط رسید خرید
/// Purchase Receipt Line
/// </summary>
public class PurchaseReceiptLine : BaseEntity
{
    /// <summary>
    /// شناسه رسید
    /// Receipt ID
    /// </summary>
    public Guid ReceiptId { get; set; }

    /// <summary>
    /// شماره خط
    /// Line number
    /// </summary>
    public int LineNo { get; set; }

    /// <summary>
    /// شناسه محصول
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// شناسه آیتم سفارش خرید
    /// Purchase order item ID
    /// </summary>
    public Guid? PurchaseOrderItemId { get; set; }

    /// <summary>
    /// تعداد سفارش داده شده
    /// Ordered quantity
    /// </summary>
    public decimal OrderedQuantity { get; set; } = 0;

    /// <summary>
    /// تعداد دریافت شده
    /// Received quantity
    /// </summary>
    public decimal ReceivedQuantity { get; set; } = 0;

    /// <summary>
    /// تعداد باقیمانده
    /// Remaining quantity
    /// </summary>
    public decimal RemainingQuantity { get; set; } = 0;

    /// <summary>
    /// قیمت واحد
    /// Unit price
    /// </summary>
    public decimal UnitPrice { get; set; } = 0;

    /// <summary>
    /// مبلغ کل
    /// Total amount
    /// </summary>
    public decimal TotalAmount { get; set; } = 0;

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// رسید مرتبط
    /// Related receipt
    /// </summary>
    public PurchaseReceipt Receipt { get; set; } = null!;

    /// <summary>
    /// محصول مرتبط
    /// Related product
    /// </summary>
    public Products.Product Product { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت خط رسید خرید
/// Purchase Receipt Line entity configuration
/// </summary>
public class PurchaseReceiptLineConfiguration : IEntityTypeConfiguration<PurchaseReceiptLine>
{
    public void Configure(EntityTypeBuilder<PurchaseReceiptLine> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description).HasMaxLength(1000);

        // Configure decimal properties with precision
        builder.Property(e => e.OrderedQuantity).HasPrecision(18, 4);
        builder.Property(e => e.ReceivedQuantity).HasPrecision(18, 4);
        builder.Property(e => e.RemainingQuantity).HasPrecision(18, 4);
        builder.Property(e => e.UnitPrice).HasPrecision(18, 2);
        builder.Property(e => e.TotalAmount).HasPrecision(18, 2);

        builder.HasIndex(e => e.ReceiptId);
        builder.HasIndex(e => e.ProductId);
    }
}
