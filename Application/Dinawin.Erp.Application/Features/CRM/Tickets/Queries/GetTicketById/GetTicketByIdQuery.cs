using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.CRM.Tickets.Queries.GetTicketById;

/// <summary>
/// پرس‌وجو دریافت تیکت بر اساس شناسه
/// </summary>
public sealed class GetTicketByIdQuery : IRequest<TicketDto?>
{
    /// <summary>
    /// شناسه تیکت
    /// </summary>
    [Required(ErrorMessage = "شناسه تیکت الزامی است")]
    public Guid Id { get; set; }
}
