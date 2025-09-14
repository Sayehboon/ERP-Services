using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.Companies.Queries.GetCompanyById;

/// <summary>
/// پرس‌وجو دریافت شرکت بر اساس شناسه
/// </summary>
public sealed class GetCompanyByIdQuery : IRequest<CompanyDto>
{
    /// <summary>
    /// شناسه شرکت
    /// </summary>
    [Required(ErrorMessage = "شناسه شرکت الزامی است")]
    public Guid Id { get; set; }
}
