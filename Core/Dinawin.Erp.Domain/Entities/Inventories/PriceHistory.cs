using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class PriceHistory : BaseEntity, IAggregateRoot
{
    public Guid ProductId { get; set; }
    public decimal? OldPriceBuy { get; set; }
    public decimal? OldPriceSell { get; set; }
    public decimal? NewPriceBuy { get; set; }
    public decimal? NewPriceSell { get; set; }
    public Guid? ChangedBy { get; set; }
    public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
    public string? Note { get; set; }
}

public class PriceChange : BaseEntity, IAggregateRoot
{
    public Guid ProductId { get; set; }
    public string ChangeType { get; set; } = "sale"; // sale|cost
    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }
    public string Currency { get; set; } = "IRR";
    public string? Note { get; set; }
    public Guid? ChangedBy { get; set; }
    public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
}


