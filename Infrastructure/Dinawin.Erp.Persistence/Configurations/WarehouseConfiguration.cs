using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dinawin.Erp.Domain.Entities.Inventories;

namespace Dinawin.Erp.Persistence.Configurations;

/// <summary>
/// پیکربندی موجودیت انبار
/// Warehouse entity configuration
/// </summary>
public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    /// <summary>
    /// پیکربندی موجودیت انبار
    /// Configure warehouse entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable("Warehouses", "Inventory");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Code)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(w => w.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(w => w.Description)
            .HasMaxLength(1000);

        builder.Property(w => w.Type)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(w => w.Capacity)
            .HasColumnType("decimal(18,2)");

        builder.Property(w => w.BusinessId)
            .HasMaxLength(50)
            .HasDefaultValue("default");

        // پیکربندی Value Objects
        builder.OwnsOne(w => w.Address, address =>
        {
            address.Property(a => a.Street)
                .HasColumnName("AddressStreet")
                .HasMaxLength(200);
            
            address.Property(a => a.City)
                .HasColumnName("AddressCity")
                .HasMaxLength(100);
            
            address.Property(a => a.State)
                .HasColumnName("AddressState")
                .HasMaxLength(100);
            
            address.Property(a => a.PostalCode)
                .HasColumnName("AddressPostalCode")
                .HasMaxLength(20);
            
            address.Property(a => a.Country)
                .HasColumnName("AddressCountry")
                .HasMaxLength(100);
        });

        // روابط
        builder.HasMany(w => w.Inventories)
            .WithOne(i => i.Warehouse)
            .HasForeignKey(i => i.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(w => w.InventoryMovements)
            .WithOne(im => im.Warehouse)
            .HasForeignKey(im => im.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        // ایندکس‌ها
        builder.HasIndex(w => new { w.BusinessId, w.Code })
            .IsUnique()
            .HasDatabaseName("IX_Warehouses_Business_Code");

        builder.HasIndex(w => w.BusinessId)
            .HasDatabaseName("IX_Warehouses_BusinessId");

        builder.HasIndex(w => w.Name)
            .HasDatabaseName("IX_Warehouses_Name");
    }
}
