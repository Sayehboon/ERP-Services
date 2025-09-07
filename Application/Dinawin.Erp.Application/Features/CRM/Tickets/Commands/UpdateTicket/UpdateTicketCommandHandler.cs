using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Tickets.Commands.UpdateTicket;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی تیکت
/// </summary>
public sealed class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی تیکت
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی تیکت
    /// </summary>
    public async Task<Guid> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        if (ticket == null)
        {
            throw new ArgumentException($"تیکت با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود مشتری
        if (request.CustomerId.HasValue)
        {
            var customerExists = await _context.Customers
                .AnyAsync(c => c.Id == request.CustomerId.Value, cancellationToken);
            if (!customerExists)
            {
                throw new ArgumentException($"مشتری با شناسه {request.CustomerId} یافت نشد");
            }
        }

        // بررسی وجود کاربر ایجاد کننده
        if (request.CreatedById.HasValue)
        {
            var userExists = await _context.Users
                .AnyAsync(u => u.Id == request.CreatedById.Value, cancellationToken);
            if (!userExists)
            {
                throw new ArgumentException($"کاربر با شناسه {request.CreatedById} یافت نشد");
            }
        }

        // بررسی وجود کاربر مسئول
        if (request.AssignedToId.HasValue)
        {
            var userExists = await _context.Users
                .AnyAsync(u => u.Id == request.AssignedToId.Value, cancellationToken);
            if (!userExists)
            {
                throw new ArgumentException($"کاربر با شناسه {request.AssignedToId} یافت نشد");
            }
        }

        // بررسی وجود محصول
        if (request.ProductId.HasValue)
        {
            var productExists = await _context.Products
                .AnyAsync(p => p.Id == request.ProductId.Value, cancellationToken);
            if (!productExists)
            {
                throw new ArgumentException($"محصول با شناسه {request.ProductId} یافت نشد");
            }
        }

        // بررسی وجود سفارش فروش
        if (request.SalesOrderId.HasValue)
        {
            var salesOrderExists = await _context.SalesOrders
                .AnyAsync(so => so.Id == request.SalesOrderId.Value, cancellationToken);
            if (!salesOrderExists)
            {
                throw new ArgumentException($"سفارش فروش با شناسه {request.SalesOrderId} یافت نشد");
            }
        }

        // بررسی وجود فرصت
        if (request.OpportunityId.HasValue)
        {
            var opportunityExists = await _context.Opportunities
                .AnyAsync(o => o.Id == request.OpportunityId.Value, cancellationToken);
            if (!opportunityExists)
            {
                throw new ArgumentException($"فرصت با شناسه {request.OpportunityId} یافت نشد");
            }
        }

        ticket.Title = request.Title;
        ticket.Description = request.Description;
        ticket.TicketType = request.TicketType;
        ticket.Priority = request.Priority;
        ticket.Status = request.Status;
        ticket.CustomerId = request.CustomerId;
        ticket.CreatedById = request.CreatedById;
        ticket.AssignedToId = request.AssignedToId;
        ticket.ProductId = request.ProductId;
        ticket.SalesOrderId = request.SalesOrderId;
        ticket.OpportunityId = request.OpportunityId;
        ticket.DueDate = request.DueDate;
        ticket.ClosedDate = request.ClosedDate;
        ticket.CloseReason = request.CloseReason;
        ticket.Tags = request.Tags;
        ticket.UpdatedBy = request.UpdatedBy;
        ticket.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return ticket.Id;
    }
}
