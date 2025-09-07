using MediatR;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.CreateTask;

/// <summary>
/// دستور ایجاد وظیفه جدید
/// </summary>
public class CreateTaskCommand : IRequest<Guid>
{
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
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToUserId { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// </summary>
    public Guid CreatedByUserId { get; set; }

    /// <summary>
    /// اولویت وظیفه
    /// </summary>
    public string Priority { get; set; } = "Medium";

    /// <summary>
    /// وضعیت وظیفه
    /// </summary>
    public string Status { get; set; } = "ToDo";

    /// <summary>
    /// نوع وظیفه
    /// </summary>
    public string TaskType { get; set; } = "Task";

    /// <summary>
    /// تاریخ شروع
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// تاریخ تکمیل
    /// </summary>
    public DateTime? CompletedDate { get; set; }

    /// <summary>
    /// درصد پیشرفت
    /// </summary>
    public int ProgressPercentage { get; set; } = 0;

    /// <summary>
    /// زمان تخمینی (ساعت)
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
    /// یادداشت‌ها
    /// </summary>
    public string? Notes { get; set; }
}
