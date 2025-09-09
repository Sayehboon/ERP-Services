using Dinawin.Erp.Domain.Common;

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
    /// شناسه پروژه
    /// Project ID
    /// </summary>
    public Guid? ProjectId { get; set; }

    

    /// <summary>
    /// شناسه کاربر مسئول
    /// Assigned to user ID
    /// </summary>
    public Guid? AssignedTo { get; set; }

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
}
