using Dinawin.Erp.Domain.Entities.Inventories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

public class BinConfiguration : IEntityTypeConfiguration<Bin>
{
    public void Configure(EntityTypeBuilder<Bin> builder)
    {
        builder.ToTable("Bins", "Inventory");
        builder.Property(p => p.Code).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.Aisle).HasMaxLength(50);
        builder.Property(p => p.Shelf).HasMaxLength(50);
        builder.Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.HasOne(p => p.Warehouse)
            .WithMany()
            .HasForeignKey(p => p.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasIndex(p => new { p.WarehouseId, p.Code }).IsUnique().HasDatabaseName("IX_Bins_Warehouse_Code");
        builder.HasIndex(p => p.Code).HasDatabaseName("IX_Bins_Code");
    }
}
