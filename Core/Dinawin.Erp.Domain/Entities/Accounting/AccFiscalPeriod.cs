using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// دوره مالی
/// Fiscal Period
/// </summary>
public class AccFiscalPeriod : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه سال مالی
    /// Fiscal Year ID
    /// </summary>
    public Guid FiscalYearId { get; set; }

    /// <summary>
    /// نام دوره
    /// Period Name
    /// </summary>
    public string PeriodName { get; set; } = string.Empty;

    /// <summary>
    /// شماره دوره
    /// Period Number
    /// </summary>
    public int PeriodNumber { get; set; }

    /// <summary>
    /// تاریخ شروع
    /// Start Date
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان
    /// End Date
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// وضعیت دوره
    /// Period Status
    /// </summary>
    public string Status { get; set; } = "open";

    /// <summary>
    /// آیا دوره بسته است
    /// Is Closed
    /// </summary>
    public bool IsClosed { get; set; } = false;

    /// <summary>
    /// تاریخ بسته شدن
    /// Close Date
    /// </summary>
    public DateTime? CloseDate { get; set; }

    /// <summary>
    /// شناسه کاربر بستن دوره
    /// Closed By User ID
    /// </summary>
    public Guid? ClosedByUserId { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// آیا دوره قفل است
    /// Is Locked
    /// </summary>
    public bool IsLocked { get; set; } = false;

    /// <summary>
    /// تاریخ قفل شدن
    /// Lock Date
    /// </summary>
    public DateTime? LockDate { get; set; }

    /// <summary>
    /// شناسه کاربر قفل کننده
    /// Locked By User ID
    /// </summary>
    public Guid? LockedByUserId { get; set; }

    // Navigation Properties
    /// <summary>
    /// سال مالی
    /// Fiscal Year
    /// </summary>
    public virtual AccFiscalYear? FiscalYear { get; set; }

    /// <summary>
    /// کاربر بستن دوره
    /// Closed By User
    /// </summary>
    public virtual User? ClosedByUser { get; set; }

    /// <summary>
    /// کاربر قفل کننده
    /// Locked By User
    /// </summary>
    public virtual User? LockedByUser { get; set; }
}

/// <summary>
/// پیکربندی موجودیت دوره مالی
/// Fiscal Period entity configuration
/// </summary>
public class AccFiscalPeriodConfiguration : IEntityTypeConfiguration<AccFiscalPeriod>
{
    public void Configure(EntityTypeBuilder<AccFiscalPeriod> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.PeriodName).HasMaxLength(100);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.HasOne(e => e.FiscalYear)
            .WithMany(fy => fy.FiscalPeriods)
            .HasForeignKey(e => e.FiscalYearId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.ClosedByUser)
            .WithMany()
            .HasForeignKey(e => e.ClosedByUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.LockedByUser)
            .WithMany()
            .HasForeignKey(e => e.LockedByUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => new { e.FiscalYearId, e.PeriodNumber }).IsUnique();
        builder.HasIndex(e => e.Status);
    }
}
