using MediatR;

namespace Dinawin.Erp.Application.Features.Activities.Commands.UpdateActivity;

/// <summary>
/// Command for updating an activity
/// </summary>
public class UpdateActivityCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public string? Type { get; set; }
    public string? Subject { get; set; }
    public string? ContactName { get; set; }
    public string? AccountName { get; set; }
    public DateTime? DueDate { get; set; }
    public string? Status { get; set; }
    public string? Priority { get; set; }
    public Guid? AssignedTo { get; set; }
    public string? Description { get; set; }
    public Guid? UpdatedBy { get; set; }
}
