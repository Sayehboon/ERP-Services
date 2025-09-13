using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت وظیفه
/// Task entity
/// </summary>
public class WorkTask : BaseEntity
{
    /// <summary>
    /// عنوان وظیفه
    /// Task title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات وظیفه
    /// Task description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// وضعیت وظیفه
    /// Task status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// اولویت وظیفه
    /// Task priority
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ شروع وظیفه
    /// Task start date
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان وظیفه
    /// Task end date
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// تاریخ شروع برنامه‌ریزی شده (نام مستعار)
    /// Planned start date (alias)
    /// </summary>
    public DateTime? PlannedStartDate => StartDate;

    /// <summary>
    /// تاریخ پایان برنامه‌ریزی شده (نام مستعار)
    /// Planned end date (alias)
    /// </summary>
    public DateTime? PlannedEndDate => EndDate;

    /// <summary>
    /// تاریخ شروع واقعی
    /// Actual start date
    /// </summary>
    public DateTime? ActualStartDate { get; set; }

    /// <summary>
    /// تاریخ پایان واقعی
    /// Actual end date
    /// </summary>
    public DateTime? ActualEndDate { get; set; }

    /// <summary>
    /// تاریخ تکمیل وظیفه
    /// Task completion date
    /// </summary>
    public DateTime? CompletedDate { get; set; }

    /// <summary>
    /// درصد پیشرفت وظیفه
    /// Task progress percentage
    /// </summary>
    public int ProgressPercentage { get; set; }

    /// <summary>
    /// پیشرفت وظیفه (نام مستعار)
    /// Task progress (alias)
    /// </summary>
    public int Progress => ProgressPercentage;

    /// <summary>
    /// شناسه پروژه
    /// Project ID
    /// </summary>
    public Guid? ProjectId { get; set; }

    /// <summary>
    /// شناسه وظیفه والد
    /// Parent task ID
    /// </summary>
    public Guid? ParentTaskId { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// Assigned to user ID
    /// </summary>
    public Guid? AssignedTo { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول (نام مستعار)
    /// Assigned to user ID (alias)
    /// </summary>
    public Guid? AssignedToUserId => AssignedTo;

    /// <summary>
    /// شناسه کاربر ایجادکننده (نام مستعار)
    /// Created by user ID (alias)
    /// </summary>
    public Guid? CreatedByUserId => CreatedBy;

    /// <summary>
    /// ساعت‌های واقعی کار
    /// Actual hours worked
    /// </summary>
    public decimal ActualHours { get; set; } = 0;

    /// <summary>
    /// ساعت‌های تخمینی
    /// Estimated hours
    /// </summary>
    public decimal EstimatedHours { get; set; } = 0;

    /// <summary>
    /// برچسب‌های وظیفه
    /// Task tags
    /// </summary>
    public string? Tags { get; set; }

    /// <summary>
    /// نوع وظیفه
    /// Task type
    /// </summary>
    public string? TaskType { get; set; }

    /// <summary>
    /// یادداشت‌های وظیفه
    /// Task notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// وضعیت فعال بودن وظیفه
    /// Task active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// پروژه مرتبط
    /// Related project
    /// </summary>
    public Project? Project { get; set; }

    /// <summary>
    /// کاربر مسئول
    /// Assigned user
    /// </summary>
    public User? AssignedToUser { get; set; }
}

/// <summary>
/// پیکربندی موجودیت وظیفه
/// WorkTask entity configuration
/// </summary>
public class WorkTaskConfiguration : IEntityTypeConfiguration<WorkTask>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<WorkTask> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Description).HasMaxLength(2000);
        builder.Property(e => e.Status).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Priority).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Tags).HasMaxLength(500);
        builder.Property(e => e.TaskType).HasMaxLength(100);
        builder.Property(e => e.Notes).HasMaxLength(2000);

        // Configure decimal properties with precision
        builder.Property(e => e.ActualHours).HasPrecision(8, 2);
        builder.Property(e => e.EstimatedHours).HasPrecision(8, 2);

        builder.HasOne(e => e.AssignedToUser)
            .WithMany()
            .HasForeignKey(e => e.AssignedTo)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasIndex(e => e.Status);
        builder.HasIndex(e => e.Priority);
        builder.HasIndex(e => e.AssignedTo);
        builder.HasIndex(e => e.ProjectId);
    }
}
