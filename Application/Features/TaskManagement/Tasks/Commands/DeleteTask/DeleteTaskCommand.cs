using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.DeleteTask;

/// <summary>
/// دستور حذف وظیفه
/// </summary>
public sealed class DeleteTaskCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه وظیفه
    /// </summary>
    [Required(ErrorMessage = "شناسه وظیفه الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
