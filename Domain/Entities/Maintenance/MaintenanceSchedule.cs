using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Maintenance;

public class MaintenanceSchedule : BaseEntity, IAggregateRoot
{
    public Guid BusinessId { get; set; }
    public Guid EquipmentId { get; set; }
    public required string ScheduleName { get; set; }
    public required string MaintenanceType { get; set; }
    public required string FrequencyType { get; set; }
    public int FrequencyInterval { get; set; } = 1;
    public DateTime NextDueDate { get; set; }
    public DateTime? LastCompletedDate { get; set; }
    public int? EstimatedDurationHours { get; set; }
    public Guid? AssignedTechnician { get; set; }
    public string Instructions { get; set; }
    public string RequiredParts { get; set; }
    public string RequiredTools { get; set; }
    public bool IsActive { get; set; } = true;
}

/// <summary>
/// پیکربندی موجودیت برنامه نگهداری
/// MaintenanceSchedule entity configuration
/// </summary>
public class MaintenanceScheduleConfiguration : IEntityTypeConfiguration<MaintenanceSchedule>
{
    public void Configure(EntityTypeBuilder<MaintenanceSchedule> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.ScheduleName).IsRequired().HasMaxLength(200);
        builder.Property(e => e.MaintenanceType).IsRequired().HasMaxLength(100);
        builder.Property(e => e.FrequencyType).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Instructions).HasMaxLength(2000);
        builder.Property(e => e.RequiredParts).HasMaxLength(1000);
        builder.Property(e => e.RequiredTools).HasMaxLength(1000);

        builder.HasIndex(e => new { e.BusinessId, e.EquipmentId, e.ScheduleName }).IsUnique();
        builder.HasIndex(e => e.NextDueDate);
        builder.HasIndex(e => e.IsActive);
    }
}


