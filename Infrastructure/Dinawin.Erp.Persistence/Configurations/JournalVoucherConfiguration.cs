using Dinawin.Erp.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

public class JournalVoucherConfiguration : IEntityTypeConfiguration<JournalVoucher>
{
    public void Configure(EntityTypeBuilder<JournalVoucher> builder)
    {
        builder.ToTable("JournalVouchers", "GL");
        builder.Property(p => p.Number).HasMaxLength(50);
        builder.Property(p => p.VoucherDate).HasColumnType("date");
        builder.Property(p => p.Type).HasMaxLength(10).HasDefaultValue("JV");
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.Status).HasMaxLength(20).HasDefaultValue("draft");
        builder.Property(p => p.ApprovalStatus).HasMaxLength(20);
        builder.HasMany(p => p.Lines).WithOne().HasForeignKey(l => l.VoucherId).OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(p => new { p.FiscalYearId, p.VoucherDate }).HasDatabaseName("IX_JournalVouchers_Year_Date");
        builder.HasIndex(p => p.Number).HasDatabaseName("IX_JournalVouchers_Number");
    }
}

public class JournalLineConfiguration : IEntityTypeConfiguration<JournalLine>
{
    public void Configure(EntityTypeBuilder<JournalLine> builder)
    {
        builder.ToTable("JournalLines", "GL");
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.Debit).HasPrecision(18, 2);
        builder.Property(p => p.Credit).HasPrecision(18, 2);
        builder.HasIndex(p => p.VoucherId).HasDatabaseName("IX_JournalLines_VoucherId");
        builder.HasIndex(p => p.AccountId).HasDatabaseName("IX_JournalLines_AccountId");
    }
}
