using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

public class ApprovalWorkflow : BaseEntity, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; }
    public ICollection<ApprovalStage> Stages { get; set; } = new List<ApprovalStage>();
}

public class ApprovalStage : BaseEntity
{
    public Guid WorkflowId { get; set; }
    public int Order { get; set; }
    public string RoleRequired { get; set; } = string.Empty;
    public string Condition { get; set; }

    public ApprovalWorkflow Workflow { get; set; } = null!;
}

public class JournalApprovalLog : BaseEntity
{
    public Guid JournalId { get; set; }
    public Guid? StageId { get; set; }
    public Guid? ApprovedBy { get; set; }
    public string Action { get; set; } = string.Empty; // submitted/approved/rejected
    public string Comment { get; set; }
}

/// <summary>
/// پیکربندی موجودیت گردش کار تایید
/// Approval Workflow entity configuration
/// </summary>
public class ApprovalWorkflowConfiguration : IEntityTypeConfiguration<ApprovalWorkflow>
{
    public void Configure(EntityTypeBuilder<ApprovalWorkflow> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.HasIndex(e => e.Name);
    }
}

/// <summary>
/// پیکربندی موجودیت مرحله تایید
/// Approval Stage entity configuration
/// </summary>
public class ApprovalStageConfiguration : IEntityTypeConfiguration<ApprovalStage>
{
    public void Configure(EntityTypeBuilder<ApprovalStage> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.RoleRequired).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Condition).HasMaxLength(1000);

        builder.HasOne(e => e.Workflow)
            .WithMany(w => w.Stages)
            .HasForeignKey(e => e.WorkflowId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.WorkflowId);
        builder.HasIndex(e => e.Order);
    }
}

/// <summary>
/// پیکربندی موجودیت لاگ تایید روزنامه
/// Journal Approval Log entity configuration
/// </summary>
public class JournalApprovalLogConfiguration : IEntityTypeConfiguration<JournalApprovalLog>
{
    public void Configure(EntityTypeBuilder<JournalApprovalLog> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Action).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Comment).HasMaxLength(1000);

        builder.HasIndex(e => e.JournalId);
        builder.HasIndex(e => e.ApprovedBy);
    }
}

