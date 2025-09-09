using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Systems;

public class RateLimit : BaseEntity, IAggregateRoot
{
    public string Key { get; set; } = string.Empty;
    public int Limit { get; set; }
    public int WindowSeconds { get; set; }
}


