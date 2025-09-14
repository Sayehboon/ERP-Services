using MediatR;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Crm;

namespace Dinawin.Erp.Application.Features.CRM.Tickets.Commands.CreateTicket;

/// <summary>
/// مدیریت‌کننده دستور ایجاد تیکت
/// </summary>
public sealed class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد تیکت
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد تیکت
    /// </summary>
    public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        // اطمینان از مقداردهی شناسه ایجادکننده (در دامنه اجباری است)
        if (!request.CreatedBy.HasValue)
        {
            throw new ArgumentException("شناسه کاربر ایجادکننده الزامی است");
        }

        var ticket = new Ticket
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Type = request.TicketType,
            Priority = request.Priority,
            Status = request.Status,
            ContactId = null, // می‌توانید در صورت نیاز از درخواست پر کنید
            CreatedBy = request.CreatedBy.Value,
            AssignedTo = request.AssignedToId,
            ResolvedAt = request.ClosedDate,
            Resolution = request.CloseReason,
            Notes = null,
            CreatedAt = DateTime.UtcNow
        };

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync(cancellationToken);
        return ticket.Id;
    }
}
