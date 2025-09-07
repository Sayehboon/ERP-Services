using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities;

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

        var ticket = new Ticket
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            TicketType = request.TicketType,
            Priority = request.Priority,
            Status = request.Status,
            CustomerId = request.CustomerId,
            CreatedById = request.CreatedById,
            AssignedToId = request.AssignedToId,
            ProductId = request.ProductId,
            SalesOrderId = request.SalesOrderId,
            OpportunityId = request.OpportunityId,
            DueDate = request.DueDate,
            ClosedDate = request.ClosedDate,
            CloseReason = request.CloseReason,
            Tags = request.Tags,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync(cancellationToken);
        return ticket.Id;
    }
}
