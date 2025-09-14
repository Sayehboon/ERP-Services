using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Activities.DTOs;

namespace Dinawin.Erp.Application.Features.Activities.Queries.GetActivityById;

/// <summary>
/// Handler for getting activity by ID
/// </summary>
public class GetActivityByIdQueryHandler : IRequestHandler<GetActivityByIdQuery, ActivityDto>
{
    private readonly IApplicationDbContext _context;

    public GetActivityByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ActivityDto> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        var activity = await _context.Activities
            .Where(a => a.Id == request.Id)
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
            .FirstOrDefaultAsync(cancellationToken);

        if (activity == null)
        {
            throw new KeyNotFoundException($"Activity with ID {request.Id} not found.");
        }

        return activity;
    }
}
