using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetTaskProgress;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت پیشرفت وظیفه
/// </summary>
public sealed class GetTaskProgressQueryHandler : IRequestHandler<GetTaskProgressQuery, TaskProgressDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت پیشرفت وظیفه
    /// </summary>
    public GetTaskProgressQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت پیشرفت وظیفه
    /// </summary>
    public async Task<TaskProgressDto> Handle(GetTaskProgressQuery request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks
            .FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);

        if (task == null)
        {
            return null;
        }

        int? plannedDurationDays = null;
        if (task.StartDate.HasValue && task.EndDate.HasValue)
        {
            plannedDurationDays = (task.EndDate.Value - task.StartDate.Value).Days;
        }

        int? actualDurationDays = null;
        if (task.StartDate.HasValue && task.EndDate.HasValue && task.Status == "Completed")
        {
            actualDurationDays = (task.EndDate.Value - task.StartDate.Value).Days;
        }

        int? remainingDays = null;
        if (task.EndDate.HasValue && task.Status != "Completed")
        {
            remainingDays = (task.EndDate.Value - DateTime.UtcNow).Days;
        }

        bool isOverdue = false;
        int? overdueDays = null;
        if (task.EndDate.HasValue && task.Status != "Completed" && DateTime.UtcNow > task.EndDate.Value)
        {
            isOverdue = true;
            overdueDays = (DateTime.UtcNow - task.EndDate.Value).Days;
        }

        var subTasks = await _context.SubTasks
            .Where(st => st.TaskId == request.TaskId)
            .ToListAsync(cancellationToken);

        var completedSubTaskCount = subTasks.Count(st => st.Status == "Completed");
        var subTaskProgressPercentage = subTasks.Count > 0 ?
            (decimal)completedSubTaskCount / subTasks.Count * 100 : 0;

        var commentCount = await _context.TaskComments
            .CountAsync(tc => tc.TaskId == request.TaskId, cancellationToken);

        var attachmentCount = await _context.TaskAttachments
            .CountAsync(ta => ta.TaskId == request.TaskId, cancellationToken);

        var activityCount = await _context.TaskActivities
            .CountAsync(ta => ta.TaskId == request.TaskId, cancellationToken);

        var progressDto = new TaskProgressDto
        {
            TaskId = task.Id,
            TaskTitle = task.Title,
            TaskCode = string.Empty,
            ProgressPercentage = task.ProgressPercentage,
            Status = task.Status,
            StatusPersian = GetStatusPersian(task.Status),
            Priority = task.Priority,
            PriorityPersian = GetPriorityPersian(task.Priority),
            StartDate = task.StartDate,
            PlannedEndDate = task.EndDate,
            ActualEndDate = task.EndDate,
            PlannedDurationDays = plannedDurationDays,
            ActualDurationDays = actualDurationDays,
            RemainingDays = remainingDays,
            IsOverdue = isOverdue,
            OverdueDays = overdueDays,
            AssignedToUserId = task.AssignedTo,
            AssignedToUserName = null,
            ProjectId = task.ProjectId,
            ProjectName = null,
            SubTaskCount = subTasks.Count,
            CompletedSubTaskCount = completedSubTaskCount,
            SubTaskProgressPercentage = subTaskProgressPercentage,
            CommentCount = commentCount,
            AttachmentCount = attachmentCount,
            ActivityCount = activityCount,
            LastActivityDate = null,
            LastUpdatedDate = task.UpdatedAt,
            LastUpdatedByUserId = task.UpdatedBy,
            LastUpdatedByUserName = null,
            Description = task.Description,
            ProgressNotes = null,
            Blockers = null,
            Solutions = null
        };

        if (request.IncludeDetails)
        {
            var progressDetails = await _context.TaskProgressUpdates
                .Where(tpu => tpu.TaskId == request.TaskId)
                .OrderByDescending(tpu => tpu.UpdatedDate)
                .Take(20)
                .ToListAsync(cancellationToken);

            progressDto.ProgressDetails = progressDetails.Select(pd => new TaskProgressDetailDto
            {
                Id = pd.Id,
                UpdatedDate = pd.UpdatedDate,
                PreviousProgress = pd.PreviousProgress,
                NewProgress = pd.NewProgress,
                ChangeDescription = pd.ChangeDescription,
                UpdatedByUserId = pd.UpdatedBy,
                UpdatedByUserName = null
            }).ToList();
        }

        return progressDto;
    }

    private static string GetStatusPersian(string status) => status;
    private static string GetPriorityPersian(string priority) => priority;
}
