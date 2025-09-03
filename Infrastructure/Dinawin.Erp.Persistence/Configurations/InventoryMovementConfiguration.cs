using Dinawin.Erp.Domain.Entities.Inventories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

/// <summary>
/// پیکربندی موجودیت حرکت موجودی
/// Inventory movement entity configuration
/// </summary>
public class InventoryMovementConfiguration : IEntityTypeConfiguration<InventoryMovement>
{
    /// <summary>
    /// پیکربندی موجودیت حرکت موجودی
    /// Configure inventory movement entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<InventoryMovement> builder)
    {
        builder.ToTable("InventoryMovements", "Inventory");

        builder.HasKey(im => im.Id);

        builder.Property(im => im.Type)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(im => im.Quantity)
            .IsRequired()
            .HasColumnType("decimal(18,4)");

        builder.Property(im => im.BalanceBefore)
            .HasColumnType("decimal(18,4)");

        builder.Property(im => im.BalanceAfter)
            .HasColumnType("decimal(18,4)");

        builder.Property(im => im.ReferenceNumber)
            .HasMaxLength(100);

        builder.Property(im => im.Reason)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(im => im.Notes)
            .HasMaxLength(1000);

        builder.Property(im => im.MovementDate)
            .IsRequired();

        // پیکربندی Value Objects
        builder.OwnsOne(im => im.UnitCost, money =>
        {
            money.Property(m => m.Amount)
                .HasColumnName("UnitCost")
                .HasColumnType("decimal(18,2)");
            
            money.Property(m => m.Currency)
                .HasColumnName("UnitCostCurrency")
                .HasMaxLength(3)
                .HasDefaultValue("IRR");
        });

        builder.OwnsOne(im => im.TotalValue, money =>
        {
            money.Property(m => m.Amount)
                .HasColumnName("TotalValue")
                .HasColumnType("decimal(18,2)");
            
            money.Property(m => m.Currency)
                .HasColumnName("TotalValueCurrency")
                .HasMaxLength(3)
                .HasDefaultValue("IRR");
        });

        // روابط
        builder.HasOne(im => im.Product)
            .WithMany(p => p.InventoryMovements)
            .HasForeignKey(im => im.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(im => im.Warehouse)
            .WithMany(w => w.InventoryMovements)
            .HasForeignKey(im => im.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        // ایندکس‌ها
        builder.HasIndex(im => im.ProductId)
            .HasDatabaseName("IX_InventoryMovements_ProductId");

        builder.HasIndex(im => im.WarehouseId)
            .HasDatabaseName("IX_InventoryMovements_WarehouseId");

        builder.HasIndex(im => im.MovementDate)
            .HasDatabaseName("IX_InventoryMovements_MovementDate");

        builder.HasIndex(im => new { im.ProductId, im.WarehouseId, im.MovementDate })
            .HasDatabaseName("IX_InventoryMovements_Product_Warehouse_Date");
    }
}
