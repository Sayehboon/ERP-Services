using Dinawin.Erp.Domain.Entities.Treasury;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.ToTable("BankAccounts", "Treasury");
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Iban).HasMaxLength(50);
        builder.Property(p => p.Currency).HasMaxLength(3).IsRequired();
        builder.Property(p => p.BusinessId).HasMaxLength(50).HasDefaultValue("default");
        builder.Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.HasOne(p => p.ControlAccount)
            .WithMany()
            .HasForeignKey(p => p.ControlAccountId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasIndex(p => new { p.BusinessId, p.Name }).IsUnique().HasDatabaseName("IX_BankAccounts_Business_Name");
        builder.HasIndex(p => p.BusinessId).HasDatabaseName("IX_BankAccounts_BusinessId");
    }
}
