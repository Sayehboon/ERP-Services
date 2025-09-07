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

        // بررسی وجود کامنت‌ها یا فعالیت‌های مرتبط
        var hasComments = await _context.TicketComments.AnyAsync(tc => tc.TicketId == request.Id, cancellationToken);
        if (hasComments)
        {
            throw new InvalidOperationException("امکان حذف تیکت وجود ندارد زیرا دارای کامنت است");
        }

        var hasActivities = await _context.Activities.AnyAsync(a => a.TicketId == request.Id, cancellationToken);
        if (hasActivities)
        {
            throw new InvalidOperationException("امکان حذف تیکت وجود ندارد زیرا دارای فعالیت مرتبط است");
        }

        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
