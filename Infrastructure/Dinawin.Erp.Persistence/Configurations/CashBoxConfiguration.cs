using Dinawin.Erp.Domain.Entities.Treasury;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

public class CashBoxConfiguration : IEntityTypeConfiguration<CashBox>
{
    public void Configure(EntityTypeBuilder<CashBox> builder)
    {
        builder.ToTable("CashBoxes", "Treasury");
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Location).HasMaxLength(200);
        builder.Property(p => p.BusinessId).HasMaxLength(50).HasDefaultValue("default");
        builder.Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.HasIndex(p => new { p.BusinessId, p.Name }).IsUnique().HasDatabaseName("IX_CashBoxes_Business_Name");
        builder.HasIndex(p => p.BusinessId).HasDatabaseName("IX_CashBoxes_BusinessId");
    }
}
