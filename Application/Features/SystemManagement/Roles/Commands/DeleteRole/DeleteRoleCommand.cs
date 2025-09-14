using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Commands.DeleteRole;

/// <summary>
/// دستور حذف نقش
/// </summary>
public sealed class DeleteRoleCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه نقش
    /// </summary>
    [Required(ErrorMessage = "شناسه نقش الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
