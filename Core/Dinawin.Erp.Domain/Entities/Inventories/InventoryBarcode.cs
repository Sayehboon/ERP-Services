using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Inventories;

/// <summary>
/// بارکد موجودی
/// Inventory Barcode
/// </summary>
public class InventoryBarcode : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه محصول
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// کد بارکد
    /// Barcode code
    /// </summary>
    public string Barcode { get; set; } = string.Empty;

    /// <summary>
    /// نوع بارکد
    /// Barcode type
    /// </summary>
    public string BarcodeType { get; set; } = string.Empty;

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// محصول مرتبط
    /// Related product
    /// </summary>
    public Products.Product Product { get; set; } = null!;
}
