using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// مقادیر ابعاد حسابداری
/// Accounting Dimension Values
/// </summary>
public class AccDimensionValue : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه بعد
    /// Dimension ID
    /// </summary>
    public Guid DimensionId { get; set; }

    /// <summary>
    /// کد مقدار
    /// Value Code
    /// </summary>
    public string ValueCode { get; set; } = string.Empty;

    /// <summary>
    /// نام مقدار
    /// Value Name
    /// </summary>
    public string ValueName { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// آیا فعال است
    /// Is Active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// ترتیب نمایش
    /// Display Order
    /// </summary>
    public int DisplayOrder { get; set; } = 0;

    /// <summary>
    /// مقدار والد
    /// Parent Value
    /// </summary>
    public Guid? ParentValueId { get; set; }

    /// <summary>
    /// سطح
    /// Level
    /// </summary>
    public int Level { get; set; } = 1;

    /// <summary>
    /// مسیر سلسله مراتبی
    /// Hierarchy Path
    /// </summary>
    public string HierarchyPath { get; set; }

    // Navigation Properties
    /// <summary>
    /// بعد
    /// Dimension
    /// </summary>
    public virtual AccDimension? Dimension { get; set; }

    /// <summary>
    /// مقدار والد
    /// Parent Value
    /// </summary>
    public virtual AccDimensionValue? ParentValue { get; set; }

    /// <summary>
    /// مقادیر فرزند
    /// Child Values
    /// </summary>
    public virtual ICollection<AccDimensionValue> Children { get; set; } = new List<AccDimensionValue>();
}

/// <summary>
/// پیکربندی موجودیت مقادیر ابعاد حسابداری
/// Accounting Dimension Value entity configuration
/// </summary>
public class AccDimensionValueConfiguration : IEntityTypeConfiguration<AccDimensionValue>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<AccDimensionValue> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.ValueCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.ValueName)
            .IsRequired()
            .HasMaxLength(200);

        //builder.Property(e => e.Description)
        //    .HasMaxLength(1000);

        builder.Property(e => e.HierarchyPath)
            .HasMaxLength(500);

        //builder.HasOne(e => e.Dimension)
        //    .WithMany()
        //    .HasForeignKey(e => e.DimensionId)
        //    .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.ParentValue)
            .WithMany(e => e.Children)
            .HasForeignKey(e => e.ParentValueId)
            .OnDelete(DeleteBehavior.Restrict);

        //builder.HasIndex(e => new { e.DimensionId, e.ValueCode })
        //    .IsUnique();

        //builder.HasIndex(e => e.DimensionId);
        builder.HasIndex(e => e.ParentValueId);
        builder.HasIndex(e => e.DisplayOrder);
    }
}

///// <summary>
///// پیکربندی موجودیت مقادیر ابعاد حسابداری
///// Accounting Dimension Value entity configuration
///// </summary>
//public class AccDimensionValueConfiguration : IEntityTypeConfiguration<AccDimensionValue>
//{
//    public void Configure(EntityTypeBuilder<AccDimensionValue> builder)
//    {
//        builder.HasKey(e => e.Id);

//        builder.Property(e => e.Code).IsRequired().HasMaxLength(50);
//        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
//        builder.Property(e => e.Description).HasMaxLength(1000);

//        builder.HasOne(e => e.Dimension)
//            .WithMany()
//            .HasForeignKey(e => e.DimensionId)
//            .OnDelete(DeleteBehavior.Cascade);

//        builder.HasIndex(e => new { e.DimensionId, e.Code }).IsUnique();
//    }
//}
