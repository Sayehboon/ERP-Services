using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class InventoryTransferLine : BaseEntity
{
    public Guid NoteId { get; set; }
    public int LineNo { get; set; }
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public Guid? FromBinId { get; set; }
    public Guid? ToBinId { get; set; }
    public decimal? Amount { get; set; }

    // Navigation
    public InventoryTransferNote Note { get; set; } = null!;
    public Products.Product Product { get; set; } = null!;
}


