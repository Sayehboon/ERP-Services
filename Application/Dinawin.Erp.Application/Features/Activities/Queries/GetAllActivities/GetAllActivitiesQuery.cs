using MediatR;
using Dinawin.Erp.Application.Features.Activities.DTOs;

namespace Dinawin.Erp.Application.Features.Activities.Queries.GetAllActivities;

/// <summary>
/// Query for getting all activities with optional filtering
/// </summary>
public class GetAllActivitiesQuery : IRequest<List<ActivityDto>>
{
    public string? Type { get; set; }
    public string? Status { get; set; }
    public string? Priority { get; set; }
    public string? AssignedTo { get; set; }
    public bool? IsActive { get; set; } = true;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}
