using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Activities.Commands.UpdateActivity;

/// <summary>
/// پردازشگر دستور به‌روزرسانی فعالیت
/// </summary>
public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public UpdateActivityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور به‌روزرسانی فعالیت
    /// </summary>
    /// <param name="request">درخواست به‌روزرسانی فعالیت</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    public async Task<bool> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await _context.Activities
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        if (activity == null)
        {
            return false;
        }

        activity.Title = request.Title;
        activity.Description = request.Description;
        activity.ActivityType = request.ActivityType;
        activity.Status = request.Status;
        activity.Priority = request.Priority;
        activity.StartDate = request.StartDate;
        activity.EndDate = request.EndDate;
        activity.ContactId = request.ContactId;
        activity.LeadId = request.LeadId;
        activity.OpportunityId = request.OpportunityId;
        activity.AssignedToUserId = request.AssignedToUserId;
        activity.UpdatedByUserId = request.UpdatedByUserId;
        activity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
