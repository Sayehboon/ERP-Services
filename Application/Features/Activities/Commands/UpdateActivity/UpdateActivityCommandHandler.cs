using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Activities.Commands.UpdateActivity;

/// <summary>
/// Handler for updating an activity
/// </summary>
public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateActivityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await _context.Activities
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        if (activity == null)
        {
            return false;
        }

        // Update only provided fields
        if (!string.IsNullOrEmpty(request.Code))
            activity.Code = request.Code;

        if (!string.IsNullOrEmpty(request.Type))
            activity.Type = request.Type;

        if (!string.IsNullOrEmpty(request.Subject))
            activity.Subject = request.Subject;

        if (request.ContactName != null)
            activity.ContactName = request.ContactName;

        if (request.AccountName != null)
            activity.AccountName = request.AccountName;

        if (request.DueDate.HasValue)
            activity.DueDate = request.DueDate;

        if (!string.IsNullOrEmpty(request.Status))
            activity.Status = request.Status;

        if (!string.IsNullOrEmpty(request.Priority))
            activity.Priority = request.Priority;

        if (request.AssignedTo != null)
            activity.AssignedTo = request.AssignedTo;

        if (request.Description != null)
            activity.Description = request.Description;

        activity.UpdatedBy = request.UpdatedBy;
        activity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
