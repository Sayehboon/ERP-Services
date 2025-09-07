using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.HR.Departments.Commands.DeleteDepartment;

/// <summary>
/// دستور حذف بخش
/// </summary>
public sealed class DeleteDepartmentCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه بخش
    /// </summary>
    [Required(ErrorMessage = "شناسه بخش الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
