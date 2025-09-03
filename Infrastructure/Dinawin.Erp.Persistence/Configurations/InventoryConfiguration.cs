using Dinawin.Erp.Domain.Entities.Inventories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

/// <summary>
/// پیکربندی موجودیت موجودی انبار
/// Inventory entity configuration
/// </summary>
public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    /// <summary>
    /// پیکربندی موجودیت موجودی انبار
    /// Configure inventory entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventories", "Inventory");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Quantity)
            .IsRequired()
            .HasColumnType("decimal(18,4)");

        builder.Property(i => i.ReservedQuantity)
            .HasColumnType("decimal(18,4)");

        builder.Property(i => i.MinStockAlert)
            .HasColumnType("decimal(18,4)");

        builder.Property(i => i.MaxStockLevel)
            .HasColumnType("decimal(18,4)");

        builder.Property(i => i.ReorderPoint)
            .HasColumnType("decimal(18,4)");

        builder.Property(i => i.SafetyStock)
            .HasColumnType("decimal(18,4)");

        builder.Property(i => i.LastMovementDate);

        // پیکربندی Value Objects
        builder.OwnsOne(i => i.AverageCost, money =>
        {
            money.Property(m => m.Amount)
                .HasColumnName("AverageCost")
                .HasColumnType("decimal(18,2)");
            
            money.Property(m => m.Currency)
                .HasColumnName("AverageCostCurrency")
                .HasMaxLength(3)
                .HasDefaultValue("IRR");
        });

        builder.OwnsOne(i => i.LastPurchaseCost, money =>
        {
            money.Property(m => m.Amount)
                .HasColumnName("LastPurchaseCost")
                .HasColumnType("decimal(18,2)");
            
            money.Property(m => m.Currency)
                .HasColumnName("LastPurchaseCostCurrency")
                .HasMaxLength(3)
                .HasDefaultValue("IRR");
        });

        // روابط
        builder.HasOne(i => i.Product)
            .WithMany(p => p.Inventories)
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(i => i.Warehouse)
            .WithMany(w => w.Inventories)
            .HasForeignKey(i => i.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(i => i.Movements)
            .WithOne(m => m.Inventory)
            .HasForeignKey(m => m.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // ایندکس‌ها
        builder.HasIndex(i => new { i.ProductId, i.WarehouseId })
            .IsUnique()
            .HasDatabaseName("IX_Inventories_ProductId_WarehouseId");

        builder.HasIndex(i => i.ProductId)
            .HasDatabaseName("IX_Inventories_ProductId");

        builder.HasIndex(i => i.WarehouseId)
            .HasDatabaseName("IX_Inventories_WarehouseId");
    }
}
