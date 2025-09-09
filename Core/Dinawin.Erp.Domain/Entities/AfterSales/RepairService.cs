using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.AfterSales;

/// <summary>
/// خدمات تعمیرات
/// Repair Services
/// </summary>
public class RepairService : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب و کار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// نام خدمات
    /// Service Name
    /// </summary>
    public string ServiceName { get; set; } = string.Empty;

    /// <summary>
    /// کد خدمات
    /// Service Code
    /// </summary>
    public string ServiceCode { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// نوع خدمات
    /// Service Type
    /// </summary>
    public string ServiceType { get; set; } = string.Empty;

    /// <summary>
    /// مدت زمان تخمینی (دقیقه)
    /// Estimated Duration (minutes)
    /// </summary>
    public int? EstimatedDuration { get; set; }

    /// <summary>
    /// هزینه پایه
    /// Base Cost
    /// </summary>
    public decimal? BaseCost { get; set; }

    /// <summary>
    /// آیا فعال است
    /// Is Active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// دسته بندی
    /// Category
    /// </summary>
    public string? Category { get; set; }

    /// <summary>
    /// مهارت های مورد نیاز
    /// Required Skills
    /// </summary>
    public string? RequiredSkills { get; set; }

    /// <summary>
    /// ابزارهای مورد نیاز
    /// Required Tools
    /// </summary>
    public string? RequiredTools { get; set; }

    /// <summary>
    /// قطعات مورد نیاز
    /// Required Parts
    /// </summary>
    public string? RequiredParts { get; set; }
}

/// <summary>
/// پیکربندی موجودیت خدمات تعمیرات
/// Repair Service entity configuration
/// </summary>
public class RepairServiceConfiguration : IEntityTypeConfiguration<RepairService>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<RepairService> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.ServiceName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.ServiceCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .HasMaxLength(1000);

        builder.Property(e => e.ServiceType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Category)
            .HasMaxLength(100);

        builder.Property(e => e.RequiredSkills)
            .HasMaxLength(500);

        builder.Property(e => e.RequiredTools)
            .HasMaxLength(500);

        builder.Property(e => e.RequiredParts)
            .HasMaxLength(500);

        builder.Property(e => e.BaseCost)
            .HasPrecision(18, 2);

        builder.HasIndex(e => e.ServiceCode)
            .IsUnique();

        builder.HasIndex(e => e.BusinessId);
    }
}
