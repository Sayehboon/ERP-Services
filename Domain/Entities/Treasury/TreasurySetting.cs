using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Treasury;

public class TreasurySetting : BaseEntity, IAggregateRoot
{
    public Guid BusinessId { get; set; }
    public string DefaultCurrency { get; set; } = "IRR";
    public decimal MaxCashLimit { get; set; } = 0;
    public decimal RequireApprovalAbove { get; set; } = 0;
    public bool AutoReconciliation { get; set; }
    public string CashCountingFrequency { get; set; } = "daily";
    public string BackupFrequency { get; set; } = "daily";
    public string ReceiptTemplate { get; set; } = "standard";
    public bool AllowNegativeBalance { get; set; }
    public bool MultiCurrencySupport { get; set; }
    public string ExchangeRateSource { get; set; } = "central_bank";
}

/// <summary>
/// پیکربندی موجودیت تنظیمات خزانه
/// Treasury Setting entity configuration
/// </summary>
public class TreasurySettingConfiguration : IEntityTypeConfiguration<TreasurySetting>
{
    public void Configure(EntityTypeBuilder<TreasurySetting> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.DefaultCurrency).HasMaxLength(10);
        builder.Property(e => e.CashCountingFrequency).HasMaxLength(50);
        builder.Property(e => e.BackupFrequency).HasMaxLength(50);
        builder.Property(e => e.ReceiptTemplate).HasMaxLength(100);
        builder.Property(e => e.ExchangeRateSource).HasMaxLength(100);

        builder.Property(e => e.MaxCashLimit).HasPrecision(18, 2);
        builder.Property(e => e.RequireApprovalAbove).HasPrecision(18, 2);

        builder.HasIndex(e => e.BusinessId).IsUnique();
    }
}

