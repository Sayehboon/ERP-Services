using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

public class AccDimension : BaseEntity, IAggregateRoot
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // project, cost_center, ...
    public string Description { get; set; }
    public bool IsActive { get; set; } = true;
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



