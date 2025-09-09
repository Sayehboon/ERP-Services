using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class GrnLine : BaseEntity
{
    public Guid GrnId { get; set; }
    public int LineNo { get; set; }
    public Guid ProductId { get; set; }
    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal? TaxRate { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal Amount { get; set; }
    public DateTime? ExpiryDate { get; set; }

    // Navigation
    public GrnReceipt Grn { get; set; } = null!;
    public Products.Product Product { get; set; } = null!;
}


