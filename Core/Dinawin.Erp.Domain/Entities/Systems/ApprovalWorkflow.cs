using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Systems;

public class ApprovalWorkflow : BaseEntity, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<ApprovalStage> Stages { get; set; } = new List<ApprovalStage>();
}

public class ApprovalStage : BaseEntity
{
    public Guid WorkflowId { get; set; }
    public int Order { get; set; }
    public string RoleRequired { get; set; } = string.Empty;
    public string? Condition { get; set; }

    public ApprovalWorkflow Workflow { get; set; } = null!;
}

public class JournalApprovalLog : BaseEntity
{
    public Guid JournalId { get; set; }
    public Guid? StageId { get; set; }
    public Guid? ApprovedBy { get; set; }
    public string Action { get; set; } = string.Empty; // submitted/approved/rejected
    public string? Comment { get; set; }
}


