using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Leads.Queries.GetLeadById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت لید بر اساس شناسه
/// </summary>
public sealed class GetLeadByIdQueryHandler : IRequestHandler<GetLeadByIdQuery, LeadDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت لید بر اساس شناسه
    /// </summary>
    public GetLeadByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<LeadDto?> Handle(GetLeadByIdQuery request, CancellationToken cancellationToken)
    {
        var lead = await _context.Leads
            .Include(l => l.AssignedTo)
            .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

        if (lead == null)
        {
            return null;
        }

        var dto = _mapper.Map<LeadDto>(lead);
        dto.AssignedToName = lead.AssignedTo != null ? $"{lead.AssignedTo.FirstName} {lead.AssignedTo.LastName}" : null;
        return dto;
    }
}
