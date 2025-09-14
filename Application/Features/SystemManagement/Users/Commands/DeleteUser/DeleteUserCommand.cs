using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.Users.Commands.DeleteUser;

/// <summary>
/// دستور حذف کاربر
/// </summary>
public sealed class DeleteUserCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه کاربر
    /// </summary>
    [Required(ErrorMessage = "شناسه کاربر الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
