using MediatR;
using Dinawin.Erp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.CRM.Activities.Queries.GetActivityById;

/// <summary>
/// پردازشگر درخواست دریافت فعالیت بر اساس شناسه
/// </summary>
public class GetActivityByIdQueryHandler : IRequestHandler<GetActivityByIdQuery, ActivityDto?>
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public GetActivityByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش درخواست دریافت فعالیت بر اساس شناسه
    /// </summary>
    /// <param name="request">درخواست دریافت فعالیت</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>اطلاعات فعالیت</returns>
    public async Task<ActivityDto?> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        var activity = await _context.Activities
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
                ContactId = a.ContactId,
                ContactName = a.Contact != null ? $"{a.Contact.FirstName} {a.Contact.LastName}" : null,
                LeadId = a.LeadId,
                LeadName = a.Lead != null ? $"{a.Lead.FirstName} {a.Lead.LastName}" : null,
                OpportunityId = a.OpportunityId,
                OpportunityName = a.Opportunity != null ? a.Opportunity.Name : null,
                AssignedToUserId = a.AssignedToUserId,
                AssignedToUserName = a.AssignedToUser != null ? $"{a.AssignedToUser.FirstName} {a.AssignedToUser.LastName}" : null,
                CreatedByUserId = a.CreatedByUserId,
                CreatedByUserName = a.CreatedByUser != null ? $"{a.CreatedByUser.FirstName} {a.CreatedByUser.LastName}" : string.Empty,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);

        return activity;
    }
}
