using MediatR;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetAllTasks;

/// <summary>
/// پرس‌وجو لیست وظایف
/// </summary>
public sealed class GetAllTasksQuery : IRequest<IEnumerable<TaskDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string SearchTerm { get; init; }

    /// <summary>
    /// شناسه پروژه برای فیلتر
    /// </summary>
    public Guid? ProjectId { get; init; }

    /// <summary>
    /// شناسه کاربر مسئول برای فیلتر
    /// </summary>
    public Guid? AssignedToUserId { get; init; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده برای فیلتر
    /// </summary>
    public Guid? CreatedByUserId { get; init; }

    /// <summary>
    /// اولویت برای فیلتر
    /// </summary>
    public string Priority { get; init; }

    /// <summary>
    /// وضعیت برای فیلتر
    /// </summary>
    public string Status { get; init; }

    /// <summary>
    /// نوع وظیفه برای فیلتر
    /// </summary>
    public string TaskType { get; init; }

    /// <summary>
    /// وضعیت فعال بودن برای فیلتر
    /// </summary>
    public bool? IsActive { get; init; }

    /// <summary>
    /// تاریخ شروع از
    /// </summary>
    public DateTime? FromDate { get; init; }

    /// <summary>
    /// تاریخ شروع تا
    /// </summary>
    public DateTime? ToDate { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
