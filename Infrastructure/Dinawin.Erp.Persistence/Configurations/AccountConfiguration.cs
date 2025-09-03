using Dinawin.Erp.Domain.Entities.Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

/// <summary>
/// پیکربندی EF برای حساب دفتر کل
/// EF configuration for GL Account
/// </summary>
public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts", schema: "GL");

        builder.Property(p => p.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.IsActive)
            .HasDefaultValue(true);

        builder.Property(p => p.Description)
            .HasMaxLength(500);

        builder.Property(p => p.BusinessId)
            .HasMaxLength(50)
            .HasDefaultValue("default");

        builder.HasOne(p => p.Parent)
            .WithMany(p => p.Children)
            .HasForeignKey(p => p.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => new { p.BusinessId, p.Code })
            .IsUnique()
            .HasDatabaseName("IX_Accounts_Business_Code");

        builder.HasIndex(p => p.BusinessId)
            .HasDatabaseName("IX_Accounts_BusinessId");

        builder.HasIndex(p => p.ParentId)
            .HasDatabaseName("IX_Accounts_ParentId");
    }
}


