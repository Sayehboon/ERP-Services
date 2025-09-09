using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Maintenance;

public class MaintenanceRequest : BaseEntity, IAggregateRoot
{
    public Guid BusinessId { get; set; }
    public required string RequestNumber { get; set; }
    public Guid EquipmentId { get; set; }
    public string MaintenanceType { get; set; } = "preventive";
    public string Priority { get; set; } = "medium";
    public string Status { get; set; } = "pending";
    public DateTime RequestDate { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public int? EstimatedDurationHours { get; set; }
    public int? ActualDurationHours { get; set; }
    public Guid? RequestedBy { get; set; }
    public Guid? AssignedTo { get; set; }
    public string? Department { get; set; }
    public required string ProblemDescription { get; set; }
    public string? WorkPerformed { get; set; }
    public bool IsEmergency { get; set; }
    public string? SafetyRequirements { get; set; }
    public decimal? CostEstimate { get; set; }
    public decimal? ActualCost { get; set; }
    public string? Notes { get; set; }
}

/// <summary>
/// پیکربندی موجودیت درخواست نگهداری
/// MaintenanceRequest entity configuration
/// </summary>
public class MaintenanceRequestConfiguration : IEntityTypeConfiguration<MaintenanceRequest>
{
    public void Configure(EntityTypeBuilder<MaintenanceRequest> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.RequestNumber).IsRequired().HasMaxLength(100);
        builder.Property(e => e.MaintenanceType).HasMaxLength(50);
        builder.Property(e => e.Priority).HasMaxLength(50);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Department).HasMaxLength(100);
        builder.Property(e => e.ProblemDescription).IsRequired().HasMaxLength(2000);
        builder.Property(e => e.WorkPerformed).HasMaxLength(2000);
        builder.Property(e => e.SafetyRequirements).HasMaxLength(1000);
        builder.Property(e => e.CostEstimate).HasPrecision(18, 2);
        builder.Property(e => e.ActualCost).HasPrecision(18, 2);

        builder.HasIndex(e => new { e.BusinessId, e.RequestNumber }).IsUnique();
        builder.HasIndex(e => e.EquipmentId);
        builder.HasIndex(e => e.Status);
    }
}


