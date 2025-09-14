using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Maintenance;

public class MaintenanceWorkOrder : BaseEntity, IAggregateRoot
{
    public Guid BusinessId { get; set; }
    public required string WorkOrderNumber { get; set; }
    public Guid? RequestId { get; set; }
    public Guid EquipmentId { get; set; }
    public required string MaintenanceType { get; set; }
    public string Priority { get; set; } = "medium";
    public string Status { get; set; } = "open";
    public DateTime? ScheduledStart { get; set; }
    public DateTime? ScheduledEnd { get; set; }
    public DateTime? ActualStart { get; set; }
    public DateTime? ActualEnd { get; set; }
    public Guid? AssignedTo { get; set; }
    public required string WorkDescription { get; set; }
    public string CompletionNotes { get; set; }
    public string PartsUsedJson { get; set; }
    public decimal? LaborHours { get; set; }
    public decimal? TotalCost { get; set; }
}

/// <summary>
/// پیکربندی موجودیت دستور کار نگهداری
/// MaintenanceWorkOrder entity configuration
/// </summary>
public class MaintenanceWorkOrderConfiguration : IEntityTypeConfiguration<MaintenanceWorkOrder>
{
    public void Configure(EntityTypeBuilder<MaintenanceWorkOrder> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.WorkOrderNumber).IsRequired().HasMaxLength(100);
        builder.Property(e => e.MaintenanceType).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Priority).HasMaxLength(50);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.WorkDescription).IsRequired().HasMaxLength(2000);
        builder.Property(e => e.CompletionNotes).HasMaxLength(2000);
        builder.Property(e => e.PartsUsedJson).HasMaxLength(4000);
        builder.Property(e => e.LaborHours).HasPrecision(18, 2);
        builder.Property(e => e.TotalCost).HasPrecision(18, 2);

        builder.HasIndex(e => new { e.BusinessId, e.WorkOrderNumber }).IsUnique();
        builder.HasIndex(e => e.EquipmentId);
        builder.HasIndex(e => e.Status);
    }
}


