using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Tickets.Queries.GetTicketById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت تیکت بر اساس شناسه
/// </summary>
public sealed class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, TicketDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت تیکت بر اساس شناسه
    /// </summary>
    public GetTicketByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<TicketDto?> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _context.Tickets
            .Include(t => t.Customer)
            .Include(t => t.CreatedByUser)
            .Include(t => t.AssignedTo)
            .Include(t => t.Product)
            .Include(t => t.SalesOrder)
            .Include(t => t.Opportunity)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (ticket == null)
        {
            return null;
        }

        var dto = _mapper.Map<TicketDto>(ticket);
        dto.CustomerName = ticket.Customer?.Name;
        dto.CreatedByName = ticket.CreatedByUser != null ? $"{ticket.CreatedByUser.FirstName} {ticket.CreatedByUser.LastName}" : null;
        dto.AssignedToName = ticket.AssignedTo != null ? $"{ticket.AssignedTo.FirstName} {ticket.AssignedTo.LastName}" : null;
        dto.ProductName = ticket.Product?.Name;
        dto.SalesOrderNumber = ticket.SalesOrder?.OrderNumber;
        dto.OpportunityName = ticket.Opportunity?.Name;
        return dto;
    }
}
