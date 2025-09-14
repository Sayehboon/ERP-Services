using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

public class RateLimit : BaseEntity, IAggregateRoot
{
    public string Key { get; set; } = string.Empty;
    public int Limit { get; set; }
    public int WindowSeconds { get; set; }
}

/// <summary>
/// پیکربندی موجودیت محدودیت نرخ
/// Rate Limit entity configuration
/// </summary>
public class RateLimitConfiguration : IEntityTypeConfiguration<RateLimit>
{
    public void Configure(EntityTypeBuilder<RateLimit> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Key).IsRequired().HasMaxLength(200);

        builder.HasIndex(e => e.Key).IsUnique();
    }
}

