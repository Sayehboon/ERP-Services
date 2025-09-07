using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.HR.Employees.Commands.DeleteEmployee;

/// <summary>
/// دستور حذف کارمند
/// </summary>
public class DeleteEmployeeCommand : IRequest
{
    /// <summary>
    /// شناسه کارمند
    /// </summary>
    [Required(ErrorMessage = "شناسه کارمند الزامی است")]
    public Guid Id { get; set; }
}