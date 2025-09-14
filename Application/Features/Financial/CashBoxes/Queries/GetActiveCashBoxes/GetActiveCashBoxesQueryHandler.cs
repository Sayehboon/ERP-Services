using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetActiveCashBoxes;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت صندوق‌های نقدی فعال
/// </summary>
public sealed class GetActiveCashBoxesQueryHandler : IRequestHandler<GetActiveCashBoxesQuery, IEnumerable<CashBoxDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت صندوق‌های نقدی فعال
    /// </summary>
    public GetActiveCashBoxesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت صندوق‌های نقدی فعال
    /// </summary>
    public async Task<IEnumerable<CashBoxDto>> Handle(GetActiveCashBoxesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.CashBoxes
            .Include(cb => cb.Business)
            .Include(cb => cb.ControlAccount)
            .AsQueryable();

        // فیلتر بر اساس کسب‌وکار
        if (request.BusinessId.HasValue)
        {
            query = query.Where(cb => cb.BusinessId == request.BusinessId.Value);
        }

        var cashBoxes = await query
            .OrderBy(cb => cb.Name)
            .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<CashBoxDto>>(cashBoxes);
    }
}
