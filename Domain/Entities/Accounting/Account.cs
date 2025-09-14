namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// موجودیت حساب معین دفتر کل
/// General ledger account entity
/// </summary>
public class Account : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// کد حساب
    /// Account code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نام حساب
    /// Account name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شرح حساب
    /// Account description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// شناسه حساب والد
    /// Parent account ID
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public string BusinessId { get; set; } = "default";

    /// <summary>
    /// حساب والد
    /// Parent account
    /// </summary>
    public Account? Parent { get; set; }

    /// <summary>
    /// حساب‌های فرزند
    /// Child accounts
    /// </summary>
    public ICollection<Account> Children { get; set; } = new List<Account>();
}

/// <summary>
/// پیکربندی موجودیت حساب
/// Account entity configuration
/// </summary>
public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code).HasMaxLength(50);
        builder.Property(e => e.Name).HasMaxLength(200);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.BusinessId).HasMaxLength(100);

        builder.HasOne(e => e.Parent)
            .WithMany(e => e.Children)
            .HasForeignKey(e => e.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.Code).IsUnique(false);
        builder.HasIndex(e => e.Name);
    }
}

