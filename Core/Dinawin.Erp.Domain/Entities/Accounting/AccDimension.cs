using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

public class AccDimension : BaseEntity, IAggregateRoot
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // project, cost_center, ...
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}

public class AccDimensionValue : BaseEntity
{
    public Guid DimensionId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    public AccDimension Dimension { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت ابعاد حسابداری
/// Accounting Dimension entity configuration
/// </summary>
public class AccDimensionConfiguration : IEntityTypeConfiguration<AccDimension>
{
    public void Configure(EntityTypeBuilder<AccDimension> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Type).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.HasIndex(e => e.Code).IsUnique(false);
        builder.HasIndex(e => e.Type);
    }
}

/// <summary>
/// پیکربندی موجودیت مقادیر ابعاد حسابداری
/// Accounting Dimension Value entity configuration
/// </summary>
public class AccDimensionValueConfiguration : IEntityTypeConfiguration<AccDimensionValue>
{
    public void Configure(EntityTypeBuilder<AccDimensionValue> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.HasOne(e => e.Dimension)
            .WithMany()
            .HasForeignKey(e => e.DimensionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.DimensionId, e.Code }).IsUnique();
    }
}

