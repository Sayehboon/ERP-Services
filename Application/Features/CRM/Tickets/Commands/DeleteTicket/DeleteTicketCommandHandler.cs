using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Tickets.Commands.DeleteTicket;

/// <summary>
/// مدیریت‌کننده دستور حذف تیکت
/// </summary>
public sealed class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف تیکت
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف تیکت
    /// </summary>
    public async Task<bool> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        if (ticket == null)
        {
            throw new ArgumentException($"تیکت با شناسه {request.Id} یافت نشد");
        }

        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
