using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Crm;

namespace Dinawin.Erp.Application.Features.CRM.Activities.Commands.CreateActivity;

/// <summary>
/// پردازشگر دستور ایجاد فعالیت
/// </summary>
public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public CreateActivityCommandHandler(IApplicationDbContext context)
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
            AssignedTo = request.AssignedToUserId,
            CreatedBy = request.CreatedByUserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Activities.Add(activity);
        await _context.SaveChangesAsync(cancellationToken);

        return activity.Id;
    }
}
