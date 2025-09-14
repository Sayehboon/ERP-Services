using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.CRM.Opportunities.Queries.GetOpportunityById;

/// <summary>
/// پرس‌وجو دریافت فرصت بر اساس شناسه
/// </summary>
public sealed class GetOpportunityByIdQuery : IRequest<OpportunityDto>
{
    /// <summary>
    /// شناسه فرصت
    /// </summary>
    [Required(ErrorMessage = "شناسه فرصت الزامی است")]
    public Guid Id { get; set; }
}
