using Dinawin.Erp.Domain.Common;

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
