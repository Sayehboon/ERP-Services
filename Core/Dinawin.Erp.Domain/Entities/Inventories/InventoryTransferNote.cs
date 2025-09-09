using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class InventoryTransferNote : BaseEntity, IAggregateRoot
{
    public Guid FromWarehouseId { get; set; }
    public Guid ToWarehouseId { get; set; }
    public DateTime TransferDate { get; set; } = DateTime.UtcNow;
    public string Currency { get; set; } = "IRR";
    public string Status { get; set; } = "draft";
    public string? Number { get; set; }
    public decimal? Total { get; set; }

    // Navigation
    public Warehouse FromWarehouse { get; set; } = null!;
    public Warehouse ToWarehouse { get; set; } = null!;
    public ICollection<InventoryTransferLine> Lines { get; set; } = new List<InventoryTransferLine>();
}


