using MediatR;
using Dinawin.Erp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.CRM.Activities.Queries.GetAllActivities;

/// <summary>
/// پردازشگر درخواست دریافت تمام فعالیت‌ها
/// </summary>
public class GetAllActivitiesQueryHandler : IRequestHandler<GetAllActivitiesQuery, IEnumerable<ActivityDto>>
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public GetAllActivitiesQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش درخواست دریافت تمام فعالیت‌ها
    /// </summary>
    /// <param name="request">درخواست دریافت فعالیت‌ها</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>لیست فعالیت‌ها</returns>
    public async Task<IEnumerable<ActivityDto>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Activities.AsQueryable();

        // اعمال فیلترها
        if (request.ContactId.HasValue)
            query = query.Where(a => a.ContactId == request.ContactId.Value);

        if (request.LeadId.HasValue)
            query = query.Where(a => a.LeadId == request.LeadId.Value);

        if (request.OpportunityId.HasValue)
            query = query.Where(a => a.OpportunityId == request.OpportunityId.Value);

        if (request.AssignedToUserId.HasValue)
            query = query.Where(a => a.AssignedToUserId == request.AssignedToUserId.Value);

        if (!string.IsNullOrEmpty(request.Status))
            query = query.Where(a => a.Status == request.Status);

        if (!string.IsNullOrEmpty(request.ActivityType))
            query = query.Where(a => a.ActivityType == request.ActivityType);

        if (request.FromDate.HasValue)
            query = query.Where(a => a.StartDate >= request.FromDate.Value);

        if (request.ToDate.HasValue)
            query = query.Where(a => a.EndDate <= request.ToDate.Value);

        // مرتب‌سازی و صفحه‌بندی
        query = query.OrderByDescending(a => a.CreatedAt)
                    .Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize);

        var activities = await query
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
            .ToListAsync(cancellationToken);

        return activities;
    }
}
