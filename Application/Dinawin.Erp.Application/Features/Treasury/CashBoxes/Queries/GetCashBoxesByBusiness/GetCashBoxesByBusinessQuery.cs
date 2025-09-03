namespace Dinawin.Erp.Application.Features.Treasury.CashBoxes.Queries.GetCashBoxesByBusiness;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Treasury.CashBoxes.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetCashBoxesByBusinessQuery(string BusinessId = "default") : IRequest<IReadOnlyList<CashBoxDto>>;

public class GetCashBoxesByBusinessQueryHandler : IRequestHandler<GetCashBoxesByBusinessQuery, IReadOnlyList<CashBoxDto>>
{
    private readonly IApplicationDbContext _db;
    public GetCashBoxesByBusinessQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<CashBoxDto>> Handle(GetCashBoxesByBusinessQuery request, CancellationToken cancellationToken)
    {
        return await _db.CashBoxes.AsNoTracking()
            .Where(cb => cb.BusinessId == request.BusinessId && cb.IsActive)
            .OrderBy(cb => cb.Name)
            .Select(cb => new CashBoxDto
            {
                Id = cb.Id,
                Name = cb.Name,
                Location = cb.Location,
                BusinessId = cb.BusinessId,
                IsActive = cb.IsActive
            })
            .ToListAsync(cancellationToken);
    }
}
