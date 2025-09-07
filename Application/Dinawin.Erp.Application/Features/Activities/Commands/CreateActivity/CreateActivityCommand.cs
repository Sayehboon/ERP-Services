using MediatR;

namespace Dinawin.Erp.Application.Features.Activities.Commands.CreateActivity;

/// <summary>
/// Command for creating a new activity
/// </summary>
public class CreateActivityCommand : IRequest<Guid>
{
    public string Code { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string? ContactName { get; set; }
    public string? AccountName { get; set; }
    public DateTime? DueDate { get; set; }
    public string Status { get; set; } = "برنامه‌ریزی شده";
    public string Priority { get; set; } = "متوسط";
    public string? AssignedTo { get; set; }
    public string? Description { get; set; }
    public Guid? CreatedBy { get; set; }
}
