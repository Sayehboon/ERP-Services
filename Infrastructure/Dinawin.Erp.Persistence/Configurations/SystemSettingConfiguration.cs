using Dinawin.Erp.Domain.Entities.Systems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

public class SystemSettingConfiguration : IEntityTypeConfiguration<SystemSetting>
{
    public void Configure(EntityTypeBuilder<SystemSetting> builder)
    {
        builder.ToTable("SystemSettings", "System");
        builder.Property(p => p.Category).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Key).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Value).HasColumnType("nvarchar(max)");
        builder.Property(p => p.BusinessId).HasMaxLength(50).HasDefaultValue("default");
        
        builder.HasIndex(p => new { p.BusinessId, p.Category, p.Key }).IsUnique().HasDatabaseName("IX_SystemSettings_Business_Category_Key");
        builder.HasIndex(p => p.Category).HasDatabaseName("IX_SystemSettings_Category");
    }
}
