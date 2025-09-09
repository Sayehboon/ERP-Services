using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.AfterSales;

/// <summary>
/// گارانتی
/// Warranty
/// </summary>
public class Warranty : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب و کار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// شماره گارانتی
    /// Warranty Number
    /// </summary>
    public string WarrantyNumber { get; set; } = string.Empty;

    /// <summary>
    /// شناسه محصول
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// شناسه مشتری
    /// Customer ID
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// تاریخ شروع گارانتی
    /// Warranty Start Date
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان گارانتی
    /// Warranty End Date
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// مدت گارانتی (ماه)
    /// Warranty Duration (months)
    /// </summary>
    public int DurationMonths { get; set; }

    /// <summary>
    /// نوع گارانتی
    /// Warranty Type
    /// </summary>
    public string WarrantyType { get; set; } = string.Empty;

    /// <summary>
    /// شرایط گارانتی
    /// Warranty Terms
    /// </summary>
    public string? Terms { get; set; }

    /// <summary>
    /// وضعیت گارانتی
    /// Warranty Status
    /// </summary>
    public string Status { get; set; } = "active";

    /// <summary>
    /// آیا قابل تمدید است
    /// Is Renewable
    /// </summary>
    public bool IsRenewable { get; set; } = false;

    /// <summary>
    /// هزینه گارانتی
    /// Warranty Cost
    /// </summary>
    public decimal? WarrantyCost { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// محصول
    /// Product
    /// </summary>
    public virtual Product? Product { get; set; }

    /// <summary>
    /// مشتری
    /// Customer
    /// </summary>
    public virtual Customer? Customer { get; set; }
}

/// <summary>
/// پیکربندی موجودیت گارانتی
/// Warranty entity configuration
/// </summary>
public class WarrantyConfiguration : IEntityTypeConfiguration<Warranty>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Warranty> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.WarrantyNumber)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.WarrantyType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Terms)
            .HasMaxLength(2000);

        builder.Property(e => e.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .HasMaxLength(1000);

        builder.Property(e => e.WarrantyCost)
            .HasColumnType("decimal(18,2)");

        builder.HasOne(e => e.Product)
            .WithMany()
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Customer)
            .WithMany()
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.WarrantyNumber)
            .IsUnique();

        builder.HasIndex(e => e.ProductId);
        builder.HasIndex(e => e.CustomerId);
        builder.HasIndex(e => e.BusinessId);
    }
}
