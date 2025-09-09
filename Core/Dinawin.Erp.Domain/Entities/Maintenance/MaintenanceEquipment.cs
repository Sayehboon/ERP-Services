using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Maintenance;

/// <summary>
/// تجهیز نگهداری و تعمیرات (CMMS) مطابق Supabase: maintenance_equipment
/// </summary>
public class MaintenanceEquipment : BaseEntity, IAggregateRoot
{
    public Guid BusinessId { get; set; }
    public required string EquipmentCode { get; set; }
    public required string EquipmentName { get; set; }
    public required string EquipmentType { get; set; }
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }
    public string? SerialNumber { get; set; }
    public required string Location { get; set; }
    public DateTime? InstallationDate { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public DateTime? WarrantyEndDate { get; set; }
    public string Status { get; set; } = "active";
    public string Criticality { get; set; } = "medium";
    public string? Description { get; set; }
    public string? SpecificationsJson { get; set; }
}

/// <summary>
/// پیکربندی موجودیت تجهیز نگهداری
/// MaintenanceEquipment entity configuration
/// </summary>
public class MaintenanceEquipmentConfiguration : IEntityTypeConfiguration<MaintenanceEquipment>
{
    public void Configure(EntityTypeBuilder<MaintenanceEquipment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.EquipmentCode).IsRequired().HasMaxLength(100);
        builder.Property(e => e.EquipmentName).IsRequired().HasMaxLength(200);
        builder.Property(e => e.EquipmentType).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Manufacturer).HasMaxLength(200);
        builder.Property(e => e.Model).HasMaxLength(200);
        builder.Property(e => e.SerialNumber).HasMaxLength(200);
        builder.Property(e => e.Location).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Criticality).HasMaxLength(50);

        builder.HasIndex(e => new { e.BusinessId, e.EquipmentCode }).IsUnique();
    }
}


