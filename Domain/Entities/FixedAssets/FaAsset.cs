using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.FixedAssets;

public class FaAsset : BaseEntity, IAggregateRoot
{
    public Guid BusinessId { get; set; }
    public Guid CategoryId { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public DateTime AcquisitionDate { get; set; }
    public decimal AcquisitionCost { get; set; }
    public decimal ResidualValue { get; set; }
    public string Status { get; set; } = "active";
    public decimal AccumulatedDepreciation { get; set; }
    public DateTime? DisposedAt { get; set; }
}

/// <summary>
/// پیکربندی موجودیت دارایی ثابت
/// Fixed Asset entity configuration
/// </summary>
public class FaAssetConfiguration : IEntityTypeConfiguration<FaAsset>
{
    public void Configure(EntityTypeBuilder<FaAsset> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.AcquisitionCost).HasPrecision(18, 2);
        builder.Property(e => e.ResidualValue).HasPrecision(18, 2);
        builder.Property(e => e.AccumulatedDepreciation).HasPrecision(18, 2);

        builder.HasIndex(e => new { e.BusinessId, e.Code }).IsUnique();
        builder.HasIndex(e => e.CategoryId);
    }
}


