using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.FixedAssets;

public class FaDepreciationRun : BaseEntity, IAggregateRoot
{
    public Guid BusinessId { get; set; }
    public Guid AssetId { get; set; }
    public DateTime RunDate { get; set; }
    public int PeriodNo { get; set; }
    public decimal Amount { get; set; }
    public Guid? VoucherId { get; set; }
    public string Status { get; set; } = "draft";
}

/// <summary>
/// پیکربندی موجودیت اجرای استهلاک دارایی
/// Fixed Asset Depreciation Run entity configuration
/// </summary>
public class FaDepreciationRunConfiguration : IEntityTypeConfiguration<FaDepreciationRun>
{
    public void Configure(EntityTypeBuilder<FaDepreciationRun> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Amount).HasPrecision(18, 2);

        builder.HasIndex(e => new { e.BusinessId, e.AssetId, e.PeriodNo }).IsUnique();
    }
}


