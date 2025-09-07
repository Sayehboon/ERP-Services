using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Tickets.Queries.GetAllTickets;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست تیکت‌ها
/// </summary>
public sealed class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, IEnumerable<TicketDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست تیکت‌ها
    /// </summary>
    public GetAllTicketsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست تیکت‌ها
    /// </summary>
    public async Task<IEnumerable<TicketDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Tickets
            .Include(t => t.Customer)
            .Include(t => t.CreatedByUser)
            .Include(t => t.AssignedTo)
            .Include(t => t.Product)
            .Include(t => t.SalesOrder)
            .Include(t => t.Opportunity)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(t => 
                t.Title.ToLower().Contains(searchLower) ||
                t.Description.ToLower().Contains(searchLower) ||
                (t.Customer != null && t.Customer.Name.ToLower().Contains(searchLower)) ||
                (t.Product != null && t.Product.Name.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس نوع تیکت
        if (!string.IsNullOrWhiteSpace(request.TicketType))
        {
            query = query.Where(t => t.TicketType == request.TicketType);
        }

        // فیلتر بر اساس وضعیت
        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            query = query.Where(t => t.Status == request.Status);
        }

        // فیلتر بر اساس اولویت
        if (!string.IsNullOrWhiteSpace(request.Priority))
        {
            query = query.Where(t => t.Priority == request.Priority);
        }

        // فیلتر بر اساس مشتری
        if (request.CustomerId.HasValue)
        {
            query = query.Where(t => t.CustomerId == request.CustomerId.Value);
        }

        // فیلتر بر اساس کاربر مسئول
        if (request.AssignedToId.HasValue)
        {
            query = query.Where(t => t.AssignedToId == request.AssignedToId.Value);
        }

        // فیلتر بر اساس کاربر ایجاد کننده
        if (request.CreatedById.HasValue)
        {
            query = query.Where(t => t.CreatedById == request.CreatedById.Value);
        }

        // فیلتر بر اساس محصول
        if (request.ProductId.HasValue)
        {
            query = query.Where(t => t.ProductId == request.ProductId.Value);
        }

        // فیلتر بر اساس سفارش فروش
        if (request.SalesOrderId.HasValue)
        {
            query = query.Where(t => t.SalesOrderId == request.SalesOrderId.Value);
        }

        // فیلتر بر اساس فرصت
        if (request.OpportunityId.HasValue)
        {
            query = query.Where(t => t.OpportunityId == request.OpportunityId.Value);
        }

        // فیلتر بر اساس تاریخ مهلت
        if (request.DueDateFrom.HasValue)
        {
            query = query.Where(t => t.DueDate >= request.DueDateFrom.Value);
        }

        if (request.DueDateTo.HasValue)
        {
            query = query.Where(t => t.DueDate <= request.DueDateTo.Value);
        }

        // فیلتر بر اساس تاریخ ایجاد
        if (request.CreatedFrom.HasValue)
        {
            query = query.Where(t => t.CreatedAt >= request.CreatedFrom.Value);
        }

        if (request.CreatedTo.HasValue)
        {
            query = query.Where(t => t.CreatedAt <= request.CreatedTo.Value);
        }

        // فیلتر بر اساس تگ‌ها
        if (!string.IsNullOrWhiteSpace(request.Tags))
        {
            var tags = request.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var tag in tags)
            {
                var trimmedTag = tag.Trim();
                query = query.Where(t => t.Tags != null && t.Tags.Contains(trimmedTag));
            }
        }

        // مرتب‌سازی
        query = query.OrderByDescending(t => t.CreatedAt);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var tickets = await query.ToListAsync(cancellationToken);
        
        return tickets.Select(t => new TicketDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            TicketType = t.TicketType,
            Priority = t.Priority,
            Status = t.Status,
            CustomerId = t.CustomerId,
            CustomerName = t.Customer?.Name,
            CreatedById = t.CreatedById,
            CreatedByName = t.CreatedByUser != null ? $"{t.CreatedByUser.FirstName} {t.CreatedByUser.LastName}" : null,
            AssignedToId = t.AssignedToId,
            AssignedToName = t.AssignedTo != null ? $"{t.AssignedTo.FirstName} {t.AssignedTo.LastName}" : null,
            ProductId = t.ProductId,
            ProductName = t.Product?.Name,
            SalesOrderId = t.SalesOrderId,
            SalesOrderNumber = t.SalesOrder?.OrderNumber,
            OpportunityId = t.OpportunityId,
            OpportunityName = t.Opportunity?.Name,
            DueDate = t.DueDate,
            ClosedDate = t.ClosedDate,
            CloseReason = t.CloseReason,
            Tags = t.Tags,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            CreatedBy = t.CreatedBy,
            UpdatedBy = t.UpdatedBy
        });
    }
}
