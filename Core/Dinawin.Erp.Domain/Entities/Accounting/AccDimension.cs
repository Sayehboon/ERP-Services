using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

public class AccDimension : BaseEntity, IAggregateRoot
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // project, cost_center, ...
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}

public class AccDimensionValue : BaseEntity
{
    public Guid DimensionId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public AccDimension Dimension { get; set; } = null!;
}


