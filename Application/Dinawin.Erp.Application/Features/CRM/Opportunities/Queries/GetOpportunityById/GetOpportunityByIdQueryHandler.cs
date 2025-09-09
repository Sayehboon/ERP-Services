using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Opportunities.Queries.GetOpportunityById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت فرصت بر اساس شناسه
/// </summary>
public sealed class GetOpportunityByIdQueryHandler : IRequestHandler<GetOpportunityByIdQuery, OpportunityDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت فرصت بر اساس شناسه
    /// </summary>
    public GetOpportunityByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<OpportunityDto?> Handle(GetOpportunityByIdQuery request, CancellationToken cancellationToken)
    {
        var opportunity = await _context.Opportunities
            .Include(o => o.Lead)
            .Include(o => o.Customer)
            //.Include(o => o.Account)
            //.Include(o => o.AssignedTo)
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        if (opportunity == null)
        {
            return null;
        }

        var dto = _mapper.Map<OpportunityDto>(opportunity);
        dto.LeadName = opportunity.Lead?.Name;
        dto.CustomerName = opportunity.Customer?.Name;
        //dto.AccountName = opportunity.Account?.Name;
        //dto.AssignedToName = opportunity.AssignedTo != null ? $"{opportunity.AssignedTo.FirstName} {opportunity.AssignedTo.LastName}" : null;
        return dto;
    }
}
