using Dinawin.Erp.Domain.Entities.Treasury;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

public class CashTransactionConfiguration : IEntityTypeConfiguration<CashTransaction>
{
    public void Configure(EntityTypeBuilder<CashTransaction> builder)
    {
        builder.ToTable("CashTransactions", "Treasury");
        builder.Property(p => p.TransactionDate).IsRequired();
        builder.Property(p => p.Type).HasConversion<string>().IsRequired();
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.Status).HasConversion<string>().IsRequired();
        builder.Property(p => p.IsPosted).HasDefaultValue(false);

        builder.OwnsOne(p => p.Amount, amount =>
        {
            amount.Property(a => a.Amount).HasColumnName("Amount").HasColumnType("decimal(18,2)").IsRequired();
            amount.Property(a => a.Currency).HasColumnName("Currency").HasMaxLength(3).IsRequired();
        });

        builder.HasOne(p => p.CashBox)
            .WithMany(p => p.CashTransactions)
            .HasForeignKey(p => p.CashBoxId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.CashBoxId).HasDatabaseName("IX_CashTransactions_CashBoxId");
        builder.HasIndex(p => p.TransactionDate).HasDatabaseName("IX_CashTransactions_TransactionDate");
        builder.HasIndex(p => p.Status).HasDatabaseName("IX_CashTransactions_Status");
    }
}
