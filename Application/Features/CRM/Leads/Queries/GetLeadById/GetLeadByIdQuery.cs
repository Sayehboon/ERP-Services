using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.CRM.Leads.Queries.GetLeadById;

/// <summary>
/// پرس‌وجو دریافت لید بر اساس شناسه
/// </summary>
public sealed class GetLeadByIdQuery : IRequest<LeadDto>
{
    /// <summary>
    /// شناسه لید
    /// </summary>
    [Required(ErrorMessage = "شناسه لید الزامی است")]
    public Guid Id { get; set; }
}
