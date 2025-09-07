using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Activities.DTOs;

namespace Dinawin.Erp.Application.Features.Activities.Queries.GetAllActivities;

/// <summary>
/// Handler for getting all activities
/// </summary>
public class GetAllActivitiesQueryHandler : IRequestHandler<GetAllActivitiesQuery, List<ActivityDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllActivitiesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ActivityDto>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Activities.AsQueryable();

        // Apply filters
        if (!string.IsNullOrEmpty(request.Type))
            query = query.Where(a => a.Type == request.Type);

        if (!string.IsNullOrEmpty(request.Status))
            query = query.Where(a => a.Status == request.Status);

        if (!string.IsNullOrEmpty(request.Priority))
            query = query.Where(a => a.Priority == request.Priority);

        if (!string.IsNullOrEmpty(request.AssignedTo))
            query = query.Where(a => a.AssignedTo == request.AssignedTo);

        if (request.IsActive.HasValue)
            query = query.Where(a => a.IsActive == request.IsActive.Value);

        // Apply pagination
        query = query
            .OrderByDescending(a => a.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        var activities = await query
            .Select(a => new ActivityDto
            {
                Id = a.Id,
                Code = a.Code,
                Type = a.Type,
                Subject = a.Subject,
                ContactName = a.ContactName,
                AccountName = a.AccountName,
                DueDate = a.DueDate,
                Status = a.Status,
                Priority = a.Priority,
                AssignedTo = a.AssignedTo,
                Description = a.Description,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy,
                IsActive = a.IsActive
            })
            .ToListAsync(cancellationToken);

        return activities;
    }
}
