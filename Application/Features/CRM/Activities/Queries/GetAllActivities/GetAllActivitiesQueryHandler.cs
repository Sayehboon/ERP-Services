using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.CRM.Activities.Queries.GetAllActivities;

/// <summary>
/// پردازشگر درخواست دریافت تمام فعالیت‌ها
/// </summary>
public class GetAllActivitiesQueryHandler : IRequestHandler<GetAllActivitiesQuery, IEnumerable<ActivityDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public GetAllActivitiesQueryHandler(IApplicationDbContext context)
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
            query = query.Where(a => a.AssignedTo == request.AssignedToUserId.Value);

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
            .ToListAsync(cancellationToken);

        return activities;
    }
}
