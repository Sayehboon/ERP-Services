using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت پروژه
/// Project entity
/// </summary>
public class Project : BaseEntity
{
    /// <summary>
    /// نام پروژه
    /// Project name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات پروژه
    /// Project description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// وضعیت پروژه
    /// Project status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// اولویت پروژه
    /// Project priority
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ شروع پروژه
    /// Project start date
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان پروژه
    /// Project end date
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// تاریخ تکمیل پروژه
    /// Project completion date
    /// </summary>
    public DateTime? CompletedDate { get; set; }

    /// <summary>
    /// درصد پیشرفت پروژه
    /// Project progress percentage
    /// </summary>
    public int ProgressPercentage { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>
    

    /// <summary>
    /// شناسه کاربر مسئول
    /// Assigned to user ID
    /// </summary>
    public Guid? AssignedTo { get; set; }

    /// <summary>
    /// یادداشت‌های پروژه
    /// Project notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// وضعیت فعال بودن پروژه
    /// Project active status
    /// </summary>
    public bool IsActive { get; set; } = true;
    public Guid ManagerId { get; set; }
}

/// <summary>
/// پیکربندی موجودیت پروژه
/// Project entity configuration
/// </summary>
public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).HasMaxLength(200);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Priority).HasMaxLength(50);
        builder.Property(e => e.Notes).HasMaxLength(2000);

        builder.HasIndex(e => e.Name);
        builder.HasIndex(e => e.Status);
        builder.HasIndex(e => e.StartDate);
    }
}
