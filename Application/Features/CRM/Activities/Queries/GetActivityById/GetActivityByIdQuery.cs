using MediatR;
using Dinawin.Erp.Application.Features.CRM.Activities.DTOs;

namespace Dinawin.Erp.Application.Features.CRM.Activities.Queries.GetActivityById;

/// <summary>
/// درخواست دریافت فعالیت بر اساس شناسه
/// </summary>
public class GetActivityByIdQuery : IRequest<ActivityDto>
{
    /// <summary>
    /// شناسه فعالیت
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// سازنده درخواست
    /// </summary>
    /// <param name="id">شناسه فعالیت</param>
    public GetActivityByIdQuery(Guid id)
    {
        Id = id;
    }
}
