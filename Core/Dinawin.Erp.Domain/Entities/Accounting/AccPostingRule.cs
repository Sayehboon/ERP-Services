using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

public class AccPostingRule : BaseEntity, IAggregateRoot
{
    public Guid BusinessId { get; set; }
    public string SourceTable { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool AutoPost { get; set; }
    public bool RequireApproval { get; set; }
    public string AccountMappingJson { get; set; } = "{}";
}


