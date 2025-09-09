using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Purchase;

/// <summary>
/// موجودیت آیتم سفارش خرید
/// Purchase Order Item entity
/// </summary>
public class PurchaseOrderItem : BaseEntity
{
    /// <summary>
    /// شناسه سفارش خرید
    /// Purchase order ID
    /// </summary>
    public Guid PurchaseOrderId { get; set; }

    /// <summary>
    /// شناسه محصول
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// تعداد
    /// Quantity
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// قیمت واحد
    /// Unit price
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// درصد تخفیف
    /// Discount percentage
    /// </summary>
    public decimal DiscountPercentage { get; set; }

    /// <summary>
    /// مبلغ تخفیف
    /// Discount amount
    /// </summary>
    public decimal DiscountAmount { get; set; }

    /// <summary>
    /// مبلغ کل
    /// Total amount
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// توضیحات آیتم
    /// Item description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// یادداشت‌های آیتم
    /// Item notes
    /// </summary>
    public string? Notes { get; set; }
}
