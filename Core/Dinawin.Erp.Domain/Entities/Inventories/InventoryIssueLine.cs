using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class InventoryIssueLine : BaseEntity
{
    public Guid NoteId { get; set; }
    public int LineNo { get; set; }
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal? UnitCost { get; set; }
    public decimal? Amount { get; set; }
    public Guid? BinId { get; set; }

    // Navigation
    public InventoryIssueNote Note { get; set; } = null!;
    public Products.Product Product { get; set; } = null!;
}


