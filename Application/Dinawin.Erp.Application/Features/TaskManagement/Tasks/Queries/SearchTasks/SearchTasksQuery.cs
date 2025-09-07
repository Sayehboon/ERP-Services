using MediatR;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.SearchTasks;

/// <summary>
/// درخواست جستجوی وظایف
/// </summary>
public class SearchTasksQuery : IRequest<IEnumerable<TaskSearchDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string SearchTerm { get; set; } = string.Empty;

    /// <summary>
    /// شناسه پروژه
    /// </summary>
    public Guid? ProjectId { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToUserId { get; set; }

    /// <summary>
    /// اولویت
    /// </summary>
    public string? Priority { get; set; }

    /// <summary>
    /// وضعیت
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// نوع وظیفه
    /// </summary>
    public string? TaskType { get; set; }

    /// <summary>
    /// حداکثر تعداد نتایج
    /// </summary>
    public int MaxResults { get; set; } = 20;
}
