using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.CRM.Tickets.Commands.DeleteTicket;

/// <summary>
/// دستور حذف تیکت
/// </summary>
public sealed class DeleteTicketCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه تیکت
    /// </summary>
    [Required(ErrorMessage = "شناسه تیکت الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف‌کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }

    /// <summary>
    /// دلیل حذف
    /// </summary>
    [StringLength(500)]
    public string DeleteReason { get; set; }
}
