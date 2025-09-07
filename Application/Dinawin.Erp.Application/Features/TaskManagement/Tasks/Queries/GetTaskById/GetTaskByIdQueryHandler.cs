using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetTaskById;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت وظیفه بر اساس شناسه
/// </summary>
public sealed class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDto?>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت وظیفه بر اساس شناسه
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetTaskByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت وظیفه بر اساس شناسه
    /// </summary>
    public async Task<TaskDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks
            .Include(t => t.Project)
            .Include(t => t.AssignedToUser)
            .Include(t => t.CreatedByUser)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (task == null)
        {
            return null;
        }

        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            ProjectId = task.ProjectId,
            ProjectName = task.Project?.Name,
            AssignedToUserId = task.AssignedToUserId,
            AssignedToUserName = task.AssignedToUser?.FirstName + " " + task.AssignedToUser?.LastName,
            CreatedByUserId = task.CreatedByUserId,
            CreatedByUserName = task.CreatedByUser?.FirstName + " " + task.CreatedByUser?.LastName,
            Priority = task.Priority,
            Status = task.Status,
            TaskType = task.TaskType,
            PlannedStartDate = task.PlannedStartDate,
            PlannedEndDate = task.PlannedEndDate,
            ActualStartDate = task.ActualStartDate,
            ActualEndDate = task.ActualEndDate,
            ProgressPercentage = task.ProgressPercentage,
            EstimatedHours = task.EstimatedHours,
            ActualHours = task.ActualHours,
            Tags = task.Tags,
            IsActive = task.IsActive,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt,
            CreatedBy = task.CreatedBy,
            UpdatedBy = task.UpdatedBy
        };
    }
}
