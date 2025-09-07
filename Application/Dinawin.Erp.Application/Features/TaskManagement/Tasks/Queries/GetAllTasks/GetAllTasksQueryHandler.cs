using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetAllTasks;

/// <summary>
/// مدیریت‌کننده پرس‌وجو لیست وظایف
/// </summary>
public sealed class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو لیست وظایف
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetAllTasksQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو لیست وظایف
    /// </summary>
    public async Task<IEnumerable<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Tasks
            .Include(t => t.Project)
            .Include(t => t.AssignedToUser)
            .Include(t => t.CreatedByUser)
            .AsQueryable();

        // اعمال فیلترها
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(t => 
                t.Title.ToLower().Contains(searchTerm) ||
                (t.Description != null && t.Description.ToLower().Contains(searchTerm)) ||
                (t.Tags != null && t.Tags.ToLower().Contains(searchTerm)));
        }

        if (request.ProjectId.HasValue)
        {
            query = query.Where(t => t.ProjectId == request.ProjectId.Value);
        }

        if (request.AssignedToUserId.HasValue)
        {
            query = query.Where(t => t.AssignedToUserId == request.AssignedToUserId.Value);
        }

        if (request.CreatedByUserId.HasValue)
        {
            query = query.Where(t => t.CreatedByUserId == request.CreatedByUserId.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.Priority))
        {
            query = query.Where(t => t.Priority == request.Priority);
        }

        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            query = query.Where(t => t.Status == request.Status);
        }

        if (!string.IsNullOrWhiteSpace(request.TaskType))
        {
            query = query.Where(t => t.TaskType == request.TaskType);
        }

        if (request.IsActive.HasValue)
        {
            query = query.Where(t => t.IsActive == request.IsActive.Value);
        }

        if (request.FromDate.HasValue)
        {
            query = query.Where(t => t.PlannedStartDate >= request.FromDate.Value);
        }

        if (request.ToDate.HasValue)
        {
            query = query.Where(t => t.PlannedStartDate <= request.ToDate.Value);
        }

        // مرتب‌سازی
        query = query.OrderByDescending(t => t.CreatedAt);

        // صفحه‌بندی
        if (request.Page > 0 && request.PageSize > 0)
        {
            query = query.Skip((request.Page - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        var tasks = await query.ToListAsync(cancellationToken);

        return tasks.Select(t => new TaskDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            ProjectId = t.ProjectId,
            ProjectName = t.Project?.Name,
            AssignedToUserId = t.AssignedToUserId,
            AssignedToUserName = t.AssignedToUser?.FirstName + " " + t.AssignedToUser?.LastName,
            CreatedByUserId = t.CreatedByUserId,
            CreatedByUserName = t.CreatedByUser?.FirstName + " " + t.CreatedByUser?.LastName,
            Priority = t.Priority,
            Status = t.Status,
            TaskType = t.TaskType,
            PlannedStartDate = t.PlannedStartDate,
            PlannedEndDate = t.PlannedEndDate,
            ActualStartDate = t.ActualStartDate,
            ActualEndDate = t.ActualEndDate,
            ProgressPercentage = t.ProgressPercentage,
            EstimatedHours = t.EstimatedHours,
            ActualHours = t.ActualHours,
            Tags = t.Tags,
            IsActive = t.IsActive,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            CreatedBy = t.CreatedBy,
            UpdatedBy = t.UpdatedBy
        });
    }
}
