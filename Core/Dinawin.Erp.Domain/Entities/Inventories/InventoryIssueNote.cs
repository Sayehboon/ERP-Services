using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class InventoryIssueNote : BaseEntity, IAggregateRoot
{
    public Guid WarehouseId { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.UtcNow;
    public string Currency { get; set; } = "IRR";
    public string Status { get; set; } = "draft"; // draft|posted
    public string? Number { get; set; }
    public decimal? Total { get; set; }

    // Navigation
    public Warehouse Warehouse { get; set; } = null!;
    public ICollection<InventoryIssueLine> Lines { get; set; } = new List<InventoryIssueLine>();
}


