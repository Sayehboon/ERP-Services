using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Sales;

/// <summary>
/// موجودیت آیتم سفارش فروش
/// Sales Order Item entity
/// </summary>
public class SalesOrderItem : BaseEntity
{
    /// <summary>
    /// شناسه سفارش فروش
    /// Sales order ID
    /// </summary>
    public Guid SalesOrderId { get; set; }

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

    /// <summary>
    /// سفارش مرتبط
    /// Related sales order
    /// </summary>
    public SalesOrder? SalesOrder { get; set; }

    /// <summary>
    /// محصول مرتبط
    /// Related product
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Products.Product? Product { get; set; }
}
