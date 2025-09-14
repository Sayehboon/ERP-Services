using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.CRM.Activities.DTOs;

namespace Dinawin.Erp.Application.Features.CRM.Activities.Queries.GetActivityById;

/// <summary>
/// پردازشگر درخواست دریافت فعالیت بر اساس شناسه
/// </summary>
public class GetActivityByIdQueryHandler : IRequestHandler<GetActivityByIdQuery, ActivityDto>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public GetActivityByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش درخواست دریافت فعالیت بر اساس شناسه
    /// </summary>
    /// <param name="request">درخواست دریافت فعالیت</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>اطلاعات فعالیت</returns>
    public async Task<ActivityDto> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        var activity = await _context.Activities
            .AsNoTracking()
            .Where(a => a.Id == request.Id)
            .Select(a => new ActivityDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                ActivityType = a.ActivityType,
                Status = a.Status,
                Priority = a.Priority,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                ReminderDate = a.ReminderDate,
                ContactId = a.ContactId,
                ContactName = null,
                LeadId = a.LeadId,
                LeadName = null,
                OpportunityId = a.OpportunityId,
                OpportunityName = null,
                CreatedBy = a.CreatedBy,
                CreatedByName = null,
                AssignedTo = a.AssignedTo,
                AssignedToName = null,
                Result = a.Result,
                Notes = a.Notes,
                IsCompleted = a.IsCompleted,
                CompletedAt = a.CompletedAt,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);

        return activity;
    }
}
