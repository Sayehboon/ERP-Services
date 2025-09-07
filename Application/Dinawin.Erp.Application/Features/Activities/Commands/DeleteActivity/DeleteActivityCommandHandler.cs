using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Activities.Commands.DeleteActivity;

/// <summary>
/// Handler for deleting an activity
/// </summary>
public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteActivityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await _context.Activities
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        if (activity == null)
        {
            return false;
        }

        // Soft delete
        activity.IsActive = false;
        activity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
