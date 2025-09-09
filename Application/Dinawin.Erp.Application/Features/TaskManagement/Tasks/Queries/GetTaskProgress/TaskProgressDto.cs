namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetTaskProgress;

/// <summary>
/// DTO پیشرفت وظیفه
/// </summary>
public class TaskProgressDto
{
    /// <summary>
    /// شناسه وظیفه
    /// </summary>
    public Guid TaskId { get; set; }

    /// <summary>
    /// عنوان وظیفه
    /// </summary>
    public string TaskTitle { get; set; } = string.Empty;

    /// <summary>
    /// کد وظیفه
    /// </summary>
    public string TaskCode { get; set; } = string.Empty;

    /// <summary>
    /// درصد پیشرفت
    /// </summary>
    public decimal ProgressPercentage { get; set; }

    /// <summary>
    /// وضعیت وظیفه
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت وظیفه به فارسی
    /// </summary>
    public string StatusPersian { get; set; } = string.Empty;

    /// <summary>
    /// اولویت وظیفه
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// اولویت وظیفه به فارسی
    /// </summary>
    public string PriorityPersian { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ شروع
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان برنامه‌ریزی شده
    /// </summary>
    public DateTime? PlannedEndDate { get; set; }

    /// <summary>
    /// تاریخ پایان واقعی
    /// </summary>
    public DateTime? ActualEndDate { get; set; }

    /// <summary>
    /// مدت زمان برنامه‌ریزی شده (روز)
    /// </summary>
    public int? PlannedDurationDays { get; set; }

    /// <summary>
    /// مدت زمان واقعی (روز)
    /// </summary>
    public int? ActualDurationDays { get; set; }

    /// <summary>
    /// تعداد روزهای باقی‌مانده
    /// </summary>
    public int? RemainingDays { get; set; }

    /// <summary>
    /// آیا تاخیر دارد
    /// </summary>
    public bool IsOverdue { get; set; }

    /// <summary>
    /// تعداد روزهای تاخیر
    /// </summary>
    public int? OverdueDays { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToUserId { get; set; }

    /// <summary>
    /// نام کاربر مسئول
    /// </summary>
    public string? AssignedToUserName { get; set; }

    /// <summary>
    /// شناسه پروژه
    /// </summary>
    public Guid? ProjectId { get; set; }

    /// <summary>
    /// نام پروژه
    /// </summary>
    public string? ProjectName { get; set; }

    /// <summary>
    /// تعداد زیروظایف
    /// </summary>
    public int SubTaskCount { get; set; }

    /// <summary>
    /// تعداد زیروظایف تکمیل شده
    /// </summary>
    public int CompletedSubTaskCount { get; set; }

    /// <summary>
    /// درصد پیشرفت زیروظایف
    /// </summary>
    public decimal SubTaskProgressPercentage { get; set; }

    /// <summary>
    /// تعداد نظرات
    /// </summary>
    public int CommentCount { get; set; }

    /// <summary>
    /// تعداد فایل‌های پیوست
    /// </summary>
    public int AttachmentCount { get; set; }

    /// <summary>
    /// تعداد فعالیت‌ها
    /// </summary>
    public int ActivityCount { get; set; }

    /// <summary>
    /// تاریخ آخرین فعالیت
    /// </summary>
    public DateTime? LastActivityDate { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime? LastUpdatedDate { get; set; }

    /// <summary>
    /// شناسه کاربر آخرین به‌روزرسانی
    /// </summary>
    public Guid? LastUpdatedByUserId { get; set; }

    /// <summary>
    /// نام کاربر آخرین به‌روزرسانی
    /// </summary>
    public string? LastUpdatedByUserName { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// یادداشت‌های پیشرفت
    /// </summary>
    public string? ProgressNotes { get; set; }

    /// <summary>
    /// موانع و مشکلات
    /// </summary>
    public string? Blockers { get; set; }

    /// <summary>
    /// راه‌حل‌های پیشنهادی
    /// </summary>
    public string? Solutions { get; set; }

    /// <summary>
    /// جزئیات پیشرفت
    /// </summary>
    public List<TaskProgressDetailDto> ProgressDetails { get; set; } = new();

    /// <summary>
    /// زیروظایف
    /// </summary>
    public List<SubTaskProgressDto> SubTasks { get; set; } = new();

    /// <summary>
    /// فعالیت‌های اخیر
    /// </summary>
    public List<TaskActivityDto> RecentActivities { get; set; } = new();
}

/// <summary>
/// DTO جزئیات پیشرفت وظیفه
/// </summary>
public class TaskProgressDetailDto
{
    /// <summary>
    /// شناسه جزئیات
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// تاریخ به‌روزرسانی
    /// </summary>
    public DateTime UpdatedDate { get; set; }

    /// <summary>
    /// درصد پیشرفت قبلی
    /// </summary>
    public decimal PreviousProgress { get; set; }

    /// <summary>
    /// درصد پیشرفت جدید
    /// </summary>
    public decimal NewProgress { get; set; }

    /// <summary>
    /// تغییر پیشرفت
    /// </summary>
    public decimal ProgressChange => NewProgress - PreviousProgress;

    /// <summary>
    /// توضیحات تغییر
    /// </summary>
    public string? ChangeDescription { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی
    /// </summary>
    public Guid? UpdatedByUserId { get; set; }

    /// <summary>
    /// نام کاربر به‌روزرسانی
    /// </summary>
    public string? UpdatedByUserName { get; set; }
}

/// <summary>
/// DTO پیشرفت زیروظیفه
/// </summary>
public class SubTaskProgressDto
{
    /// <summary>
    /// شناسه زیروظیفه
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// عنوان زیروظیفه
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// درصد پیشرفت
    /// </summary>
    public decimal ProgressPercentage { get; set; }

    /// <summary>
    /// وضعیت
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت به فارسی
    /// </summary>
    public string StatusPersian { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ شروع
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToUserId { get; set; }

    /// <summary>
    /// نام کاربر مسئول
    /// </summary>
    public string? AssignedToUserName { get; set; }
}

/// <summary>
/// DTO فعالیت وظیفه
/// </summary>
public class TaskActivityDto
{
    /// <summary>
    /// شناسه فعالیت
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نوع فعالیت
    /// </summary>
    public string ActivityType { get; set; } = string.Empty;

    /// <summary>
    /// نوع فعالیت به فارسی
    /// </summary>
    public string ActivityTypePersian { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات فعالیت
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ فعالیت
    /// </summary>
    public DateTime ActivityDate { get; set; }

    /// <summary>
    /// شناسه کاربر انجام‌دهنده
    /// </summary>
    public Guid? PerformedByUserId { get; set; }

    /// <summary>
    /// نام کاربر انجام‌دهنده
    /// </summary>
    public string? PerformedByUserName { get; set; }
}
