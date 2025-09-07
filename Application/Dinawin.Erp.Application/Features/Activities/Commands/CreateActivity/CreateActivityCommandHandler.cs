using MediatR;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Infrastructure.Data.Entities.Crm;

namespace Dinawin.Erp.Application.Features.Activities.Commands.CreateActivity;

/// <summary>
/// Handler for creating a new activity
/// </summary>
public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateActivityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = new Activity
        {
            Id = Guid.NewGuid(),
            Code = request.Code,
            Type = request.Type,
            Subject = request.Subject,
            ContactName = request.ContactName,
            AccountName = request.AccountName,
            DueDate = request.DueDate,
            Status = request.Status,
            Priority = request.Priority,
            AssignedTo = request.AssignedTo,
            Description = request.Description,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        _context.Activities.Add(activity);
        await _context.SaveChangesAsync(cancellationToken);

        return activity.Id;
    }
}
