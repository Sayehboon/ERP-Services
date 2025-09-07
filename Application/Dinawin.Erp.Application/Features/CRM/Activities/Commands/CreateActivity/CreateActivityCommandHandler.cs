using MediatR;
using Dinawin.Erp.Infrastructure.Data;
using Dinawin.Erp.Infrastructure.Data.Entities.Crm;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.CRM.Activities.Commands.CreateActivity;

/// <summary>
/// پردازشگر دستور ایجاد فعالیت
/// </summary>
public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Guid>
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public CreateActivityCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور ایجاد فعالیت
    /// </summary>
    /// <param name="request">درخواست ایجاد فعالیت</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>شناسه فعالیت ایجاد شده</returns>
    public async Task<Guid> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = new Activity
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            ActivityType = request.ActivityType,
            Status = request.Status,
            Priority = request.Priority,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            ContactId = request.ContactId,
            LeadId = request.LeadId,
            OpportunityId = request.OpportunityId,
            AssignedToUserId = request.AssignedToUserId,
            CreatedByUserId = request.CreatedByUserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Activities.Add(activity);
        await _context.SaveChangesAsync(cancellationToken);

        return activity.Id;
    }
}
