using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.AfterSales;

/// <summary>
/// درخواست گارانتی
/// Warranty Claim
/// </summary>
public class WarrantyClaim : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب و کار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// شماره درخواست
    /// Claim Number
    /// </summary>
    public string ClaimNumber { get; set; } = string.Empty;

    /// <summary>
    /// شناسه گارانتی
    /// Warranty ID
    /// </summary>
    public Guid WarrantyId { get; set; }

    /// <summary>
    /// شناسه مشتری
    /// Customer ID
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// تاریخ درخواست
    /// Claim Date
    /// </summary>
    public DateTime ClaimDate { get; set; }

    /// <summary>
    /// شرح مشکل
    /// Problem Description
    /// </summary>
    public string ProblemDescription { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت درخواست
    /// Claim Status
    /// </summary>
    public string Status { get; set; } = "pending";

    /// <summary>
    /// اولویت
    /// Priority
    /// </summary>
    public string Priority { get; set; } = "medium";

    /// <summary>
    /// تاریخ بررسی
    /// Review Date
    /// </summary>
    public DateTime? ReviewDate { get; set; }

    /// <summary>
    /// تاریخ تصمیم گیری
    /// Decision Date
    /// </summary>
    public DateTime? DecisionDate { get; set; }

    /// <summary>
    /// تصمیم
    /// Decision
    /// </summary>
    public string? Decision { get; set; }

    /// <summary>
    /// توضیحات تصمیم
    /// Decision Notes
    /// </summary>
    public string? DecisionNotes { get; set; }

    /// <summary>
    /// هزینه تعمیر
    /// Repair Cost
    /// </summary>
    public decimal? RepairCost { get; set; }

    /// <summary>
    /// هزینه قابل قبول
    /// Acceptable Cost
    /// </summary>
    public decimal? AcceptableCost { get; set; }

    /// <summary>
    /// تاریخ تکمیل
    /// Completion Date
    /// </summary>
    public DateTime? CompletionDate { get; set; }

    /// <summary>
    /// شناسه تکنسین
    /// Technician ID
    /// </summary>
    public Guid? TechnicianId { get; set; }

    /// <summary>
    /// توضیحات تکنسین
    /// Technician Notes
    /// </summary>
    public string? TechnicianNotes { get; set; }

    // Navigation Properties
    /// <summary>
    /// گارانتی
    /// Warranty
    /// </summary>
    public virtual Warranty? Warranty { get; set; }

    /// <summary>
    /// مشتری
    /// Customer
    /// </summary>
    public virtual Customer? Customer { get; set; }

    /// <summary>
    /// تکنسین
    /// Technician
    /// </summary>
    public virtual Technician? Technician { get; set; }
}

/// <summary>
/// پیکربندی موجودیت درخواست گارانتی
/// Warranty Claim entity configuration
/// </summary>
public class WarrantyClaimConfiguration : IEntityTypeConfiguration<WarrantyClaim>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<WarrantyClaim> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.ClaimNumber)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.ProblemDescription)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(e => e.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Priority)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Decision)
            .HasMaxLength(100);

        builder.Property(e => e.DecisionNotes)
            .HasMaxLength(2000);

        builder.Property(e => e.TechnicianNotes)
            .HasMaxLength(2000);

        builder.Property(e => e.RepairCost)
            .HasPrecision(18, 2);

        builder.Property(e => e.AcceptableCost)
            .HasPrecision(18, 2);

        builder.HasOne(e => e.Warranty)
            .WithMany()
            .HasForeignKey(e => e.WarrantyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Customer)
            .WithMany()
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Technician)
            .WithMany()
            .HasForeignKey(e => e.TechnicianId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.ClaimNumber)
            .IsUnique();

        builder.HasIndex(e => e.WarrantyId);
        builder.HasIndex(e => e.CustomerId);
        builder.HasIndex(e => e.TechnicianId);
        builder.HasIndex(e => e.BusinessId);
    }
}
