using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Inventories;

public class PriceHistory : BaseEntity, IAggregateRoot
{
    public Guid ProductId { get; set; }
    public decimal? OldPriceBuy { get; set; }
    public decimal? OldPriceSell { get; set; }
    public decimal? NewPriceBuy { get; set; }
    public decimal? NewPriceSell { get; set; }
    public Guid? ChangedBy { get; set; }
    public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
    public string Note { get; set; }
}

public class PriceChange : BaseEntity, IAggregateRoot
{
    public Guid ProductId { get; set; }
    public string ChangeType { get; set; } = "sale"; // sale|cost
    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }
    public string Currency { get; set; } = "IRR";
    public string Note { get; set; }
    public Guid? ChangedBy { get; set; }
    public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// پیکربندی موجودیت تاریخچه قیمت
/// Price History entity configuration
/// </summary>
public class PriceHistoryConfiguration : IEntityTypeConfiguration<PriceHistory>
{
    public void Configure(EntityTypeBuilder<PriceHistory> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Note).HasMaxLength(1000);

        // Configure decimal properties with precision
        builder.Property(e => e.OldPriceBuy).HasPrecision(18, 2);
        builder.Property(e => e.OldPriceSell).HasPrecision(18, 2);
        builder.Property(e => e.NewPriceBuy).HasPrecision(18, 2);
        builder.Property(e => e.NewPriceSell).HasPrecision(18, 2);

        builder.HasIndex(e => e.ProductId);
        builder.HasIndex(e => e.ChangedAt);
    }
}

/// <summary>
/// پیکربندی موجودیت تغییر قیمت
/// Price Change entity configuration
/// </summary>
public class PriceChangeConfiguration : IEntityTypeConfiguration<PriceChange>
{
    public void Configure(EntityTypeBuilder<PriceChange> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.ChangeType).HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Note).HasMaxLength(1000);

        // Configure decimal properties with precision
        builder.Property(e => e.OldPrice).HasPrecision(18, 2);
        builder.Property(e => e.NewPrice).HasPrecision(18, 2);

        builder.HasIndex(e => e.ProductId);
        builder.HasIndex(e => e.ChangedAt);
    }
}
