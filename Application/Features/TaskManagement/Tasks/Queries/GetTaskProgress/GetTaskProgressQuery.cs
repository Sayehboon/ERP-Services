using MediatR;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetTaskProgress;

/// <summary>
/// پرس‌وجو دریافت پیشرفت وظیفه
/// </summary>
public sealed class GetTaskProgressQuery : IRequest<TaskProgressDto>
{
    /// <summary>
    /// شناسه وظیفه
    /// </summary>
    public required Guid TaskId { get; init; }

    /// <summary>
    /// آیا شامل جزئیات باشد
    /// </summary>
    public bool IncludeDetails { get; init; } = true;
}
