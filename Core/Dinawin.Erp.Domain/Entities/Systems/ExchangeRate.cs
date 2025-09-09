using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

/// <summary>
/// نرخ ارز
/// Exchange Rate
/// </summary>
public class ExchangeRate : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// ارز مبدا
    /// From currency
    /// </summary>
    public string FromCurrency { get; set; } = string.Empty;

    /// <summary>
    /// ارز مقصد
    /// To currency
    /// </summary>
    public string ToCurrency { get; set; } = string.Empty;

    /// <summary>
    /// نرخ ارز
    /// Exchange rate
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// تاریخ نرخ
    /// Rate date
    /// </summary>
    public DateTime RateDate { get; set; }

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// منبع نرخ
    /// Rate source
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }
}

/// <summary>
/// پیکربندی موجودیت نرخ ارز
/// Exchange Rate entity configuration
/// </summary>
public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
{
    public void Configure(EntityTypeBuilder<ExchangeRate> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.FromCurrency).IsRequired().HasMaxLength(10);
        builder.Property(e => e.ToCurrency).IsRequired().HasMaxLength(10);
        builder.Property(e => e.Source).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.Rate).HasPrecision(18, 6);

        builder.HasIndex(e => new { e.FromCurrency, e.ToCurrency, e.RateDate }).IsUnique();
        builder.HasIndex(e => e.RateDate);
        builder.HasIndex(e => e.IsActive);
    }
}
