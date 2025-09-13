using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// موجودیت حساب کل
/// Chart of Account entity
/// </summary>
public class ChartOfAccount : BaseEntity
{
    /// <summary>
    /// کد حساب
    /// Account code
    /// </summary>
    public string AccountCode { get; set; } = string.Empty;

    /// <summary>
    /// نام حساب
    /// Account name
    /// </summary>
    public string AccountName { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات حساب
    /// Account description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// نوع حساب
    /// Account type
    /// </summary>
    public string AccountType { get; set; } = string.Empty;

    /// <summary>
    /// سطح حساب
    /// Account level
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// شناسه حساب والد
    /// Parent account ID
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// مسیر حساب
    /// Account path
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// وضعیت فعال بودن حساب
    /// Account active status
    /// </summary>
    public bool IsActive { get; set; } = true;
    public string? AccountCategory { get; set; }
    public Guid? ParentAccountId { get; set; }
    public string Currency { get; set; } = string.Empty;
    public decimal? ExchangeRate { get; set; }
    public string? AccountNameEn { get; set; }
    public string BalanceType { get; set; } = string.Empty;
    public bool IsEditable { get; set; }
    public bool IsDeletable { get; set; }
    public int DisplayOrder { get; set; }
    public Guid CreatedByUserId { get; set; }
    public string NormalBalance { get; set; }
    public bool IsPostable { get; set; }

    /// <summary>
    /// حساب والد
    /// Parent account
    /// </summary>
    public ChartOfAccount? ParentAccount { get; set; }

    /// <summary>
    /// حساب‌های فرزند
    /// Child accounts
    /// </summary>
    public ICollection<ChartOfAccount> ChildAccounts { get; set; } = new List<ChartOfAccount>();
}

/// <summary>
/// پیکربندی موجودیت حساب کل
/// Chart of Account entity configuration
/// </summary>
public class ChartOfAccountConfiguration : IEntityTypeConfiguration<ChartOfAccount>
{
    public void Configure(EntityTypeBuilder<ChartOfAccount> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.AccountCode).HasMaxLength(50);
        builder.Property(e => e.AccountName).HasMaxLength(200);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.AccountType).HasMaxLength(100);
        builder.Property(e => e.Path).HasMaxLength(500);
        builder.Property(e => e.AccountCategory).HasMaxLength(100);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.AccountNameEn).HasMaxLength(200);
        builder.Property(e => e.BalanceType).HasMaxLength(50);
        builder.Property(e => e.NormalBalance).HasMaxLength(50);

        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);

        builder.HasOne(e => e.ParentAccount)
            .WithMany(c => c.ChildAccounts)
            .HasForeignKey(e => e.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.AccountCode).IsUnique(false);
        builder.HasIndex(e => e.AccountName);
    }
}
