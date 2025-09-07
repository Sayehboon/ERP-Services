namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetAllTasks;

/// <summary>
/// مدل انتقال داده وظیفه
/// </summary>
public sealed class TaskDto
{
    /// <summary>
    /// شناسه وظیفه
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// عنوان وظیفه
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات وظیفه
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه پروژه
    /// </summary>
    public Guid? ProjectId { get; set; }

    /// <summary>
    /// نام پروژه
    /// </summary>
    public string? ProjectName { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToUserId { get; set; }

    /// <summary>
    /// نام کاربر مسئول
    /// </summary>
    public string? AssignedToUserName { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedByUserId { get; set; }

    /// <summary>
    /// نام کاربر ایجاد کننده
    /// </summary>
    public string? CreatedByUserName { get; set; }

    /// <summary>
    /// اولویت وظیفه
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت وظیفه
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// نوع وظیفه
    /// </summary>
    public string? TaskType { get; set; }

    /// <summary>
    /// تاریخ شروع برنامه‌ریزی شده
    /// </summary>
    public DateTime? PlannedStartDate { get; set; }

    /// <summary>
    /// تاریخ پایان برنامه‌ریزی شده
    /// </summary>
    public DateTime? PlannedEndDate { get; set; }

    /// <summary>
    /// تاریخ شروع واقعی
    /// </summary>
    public DateTime? ActualStartDate { get; set; }

    /// <summary>
    /// تاریخ پایان واقعی
    /// </summary>
    public DateTime? ActualEndDate { get; set; }

    /// <summary>
    /// درصد پیشرفت (0-100)
    /// </summary>
    public int ProgressPercentage { get; set; }

    /// <summary>
    /// تخمین زمان (ساعت)
    /// </summary>
    public decimal? EstimatedHours { get; set; }

    /// <summary>
    /// زمان صرف شده (ساعت)
    /// </summary>
    public decimal? ActualHours { get; set; }

    /// <summary>
    /// برچسب‌ها
    /// </summary>
    public string? Tags { get; set; }

    /// <summary>
    /// آیا وظیفه فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
