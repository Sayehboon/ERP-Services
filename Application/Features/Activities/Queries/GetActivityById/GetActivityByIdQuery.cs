using MediatR;
using Dinawin.Erp.Application.Features.Activities.DTOs;

namespace Dinawin.Erp.Application.Features.Activities.Queries.GetActivityById;

/// <summary>
/// Query for getting activity by ID
/// </summary>
public class GetActivityByIdQuery : IRequest<ActivityDto>
{
    public Guid Id { get; set; }
}
