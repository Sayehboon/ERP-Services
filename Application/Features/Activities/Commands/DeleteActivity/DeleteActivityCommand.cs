using MediatR;

namespace Dinawin.Erp.Application.Features.Activities.Commands.DeleteActivity;

/// <summary>
/// Command for deleting an activity
/// </summary>
public class DeleteActivityCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
