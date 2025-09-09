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
            .Include(t => t.Contact)
            .Include(t => t.AssignedUser)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (ticket == null)
        {
            return null;
        }

        var dto = _mapper.Map<TicketDto>(ticket);
        dto.CustomerName = null;
        dto.CreatedByName = null;
        dto.AssignedToName = ticket.AssignedUser != null ? $"{ticket.AssignedUser.FirstName} {ticket.AssignedUser.LastName}" : null;
        dto.ProductName = null;
        dto.SalesOrderNumber = null;
        dto.OpportunityName = null;
        return dto;
    }
}
