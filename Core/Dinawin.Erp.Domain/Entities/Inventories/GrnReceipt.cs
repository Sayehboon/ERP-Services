using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class GrnReceipt : BaseEntity, IAggregateRoot
{
    public Guid VendorId { get; set; }
    public Guid WarehouseId { get; set; }
    public DateTime ReceiptDate { get; set; } = DateTime.UtcNow;
    public string? Number { get; set; }
    public string Status { get; set; } = "draft";
    public string Currency { get; set; } = "IRR";
    public decimal? ExchangeRate { get; set; }
    public decimal Subtotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal Total { get; set; }
    public Guid? PoOrderId { get; set; }

    // Navigation
    public Warehouse Warehouse { get; set; } = null!;
    public ICollection<GrnLine> Lines { get; set; } = new List<GrnLine>();
}


