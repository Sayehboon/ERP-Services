namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.SearchTasks;

/// <summary>
/// DTO جستجوی وظیفه
/// </summary>
public class TaskSearchDto
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
    /// توضیحات
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// شناسه پروژه
    /// </summary>
    public Guid? ProjectId { get; set; }

    /// <summary>
    /// نام پروژه
    /// </summary>
    public string ProjectName { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToUserId { get; set; }

    /// <summary>
    /// نام کاربر مسئول
    /// </summary>
    public string AssignedToUserName { get; set; }

    /// <summary>
    /// اولویت
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// نوع وظیفه
    /// </summary>
    public string TaskType { get; set; }

    /// <summary>
    /// درصد پیشرفت
    /// </summary>
    public int Progress { get; set; }

    /// <summary>
    /// تاریخ شروع
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }
}
