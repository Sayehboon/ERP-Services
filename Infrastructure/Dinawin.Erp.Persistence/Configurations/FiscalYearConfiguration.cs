using Dinawin.Erp.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

public class FiscalYearConfiguration : IEntityTypeConfiguration<FiscalYear>
{
    public void Configure(EntityTypeBuilder<FiscalYear> builder)
    {
        builder.ToTable("FiscalYears", "GL");
        builder.Property(p => p.Code).HasMaxLength(20).IsRequired();
        builder.Property(p => p.YearStart).HasColumnType("date");
        builder.Property(p => p.YearEnd).HasColumnType("date");
        builder.Property(p => p.IsActive).HasDefaultValue(true);
        builder.HasIndex(p => p.Code).IsUnique().HasDatabaseName("IX_FiscalYears_Code");
        builder.HasMany(p => p.Periods).WithOne().HasForeignKey(p => p.FiscalYearId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class FiscalPeriodConfiguration : IEntityTypeConfiguration<FiscalPeriod>
{
    public void Configure(EntityTypeBuilder<FiscalPeriod> builder)
    {
        builder.ToTable("FiscalPeriods", "GL");
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.StartDate).HasColumnType("date");
        builder.Property(p => p.EndDate).HasColumnType("date");
        builder.Property(p => p.Status).HasMaxLength(20).HasDefaultValue("open");
        builder.HasIndex(p => new { p.FiscalYearId, p.PeriodNo }).IsUnique().HasDatabaseName("IX_FiscalPeriods_Year_Period");
    }
}
