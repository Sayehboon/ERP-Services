using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.SearchTasks;

/// <summary>
/// پردازشگر درخواست جستجوی وظایف
/// </summary>
public class SearchTasksQueryHandler : IRequestHandler<SearchTasksQuery, IEnumerable<TaskSearchDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public SearchTasksQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش درخواست
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>لیست وظایف مطابق جستجو</returns>
    public async Task<IEnumerable<TaskSearchDto>> Handle(SearchTasksQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Tasks.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(t =>
                t.Title.ToLower().Contains(searchTerm) ||
                (t.Description != null && t.Description.ToLower().Contains(searchTerm)));
        }

        if (request.ProjectId.HasValue)
        {
            query = query.Where(t => t.ProjectId == request.ProjectId.Value);
        }

        if (request.AssignedToUserId.HasValue)
        {
            query = query.Where(t => t.AssignedTo == request.AssignedToUserId.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.Priority))
        {
            query = query.Where(t => t.Priority == request.Priority);
        }

        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            query = query.Where(t => t.Status == request.Status);
        }

        var tasks = await query
            .Select(t => new TaskSearchDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                ProjectId = t.ProjectId,
                ProjectName = null,
                AssignedToUserId = t.AssignedTo,
                AssignedToUserName = null,
                Priority = t.Priority,
                Status = t.Status,
                TaskType = null,
                Progress = t.ProgressPercentage,
                StartDate = t.StartDate,
                DueDate = t.EndDate,
                IsActive = t.IsActive
            })
            .Take(request.MaxResults)
            .ToListAsync(cancellationToken);

        return tasks;
    }
}
