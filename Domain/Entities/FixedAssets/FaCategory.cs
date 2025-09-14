using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.FixedAssets;

public class FaCategory : BaseEntity, IAggregateRoot
{
    public Guid BusinessId { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public int UsefulLifeMonths { get; set; } = 60;
    public string DepreciationMethod { get; set; } = "straight_line";
    public Guid? ExpenseAccountId { get; set; }
    public Guid? AccumulatedDepAccountId { get; set; }
}

/// <summary>
/// پیکربندی موجودیت دسته دارایی ثابت
/// Fixed Asset Category entity configuration
/// </summary>
public class FaCategoryConfiguration : IEntityTypeConfiguration<FaCategory>
{
    public void Configure(EntityTypeBuilder<FaCategory> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.DepreciationMethod).HasMaxLength(100);

        builder.HasIndex(e => new { e.BusinessId, e.Code }).IsUnique();
    }
}


