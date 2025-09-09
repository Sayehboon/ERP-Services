using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Purchase;

/// <summary>
/// خط برگشت خرید
/// Purchase Return Line
/// </summary>
public class PurchaseReturnLine : BaseEntity
{
    /// <summary>
    /// شناسه برگشت
    /// Return ID
    /// </summary>
    public Guid ReturnId { get; set; }

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
    /// تعداد برگشتی
    /// Returned quantity
    /// </summary>
    public decimal ReturnedQuantity { get; set; } = 0;

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
    /// برگشت مرتبط
    /// Related return
    /// </summary>
    public PurchaseReturn Return { get; set; } = null!;

    /// <summary>
    /// محصول مرتبط
    /// Related product
    /// </summary>
    public Products.Product Product { get; set; } = null!;
}
