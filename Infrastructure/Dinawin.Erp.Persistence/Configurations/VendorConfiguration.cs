using Dinawin.Erp.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        builder.ToTable("Vendors", "AP");
        builder.Property(p => p.Code).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
        builder.Property(p => p.IsActive).HasDefaultValue(true);
        builder.HasIndex(p => p.Code).IsUnique().HasDatabaseName("IX_Vendors_Code");
        builder.HasIndex(p => p.Name).HasDatabaseName("IX_Vendors_Name");
    }
}


