using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.Companies.Commands.DeleteCompany;

/// <summary>
/// دستور حذف شرکت
/// </summary>
public sealed class DeleteCompanyCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه شرکت
    /// </summary>
    [Required(ErrorMessage = "شناسه شرکت الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
