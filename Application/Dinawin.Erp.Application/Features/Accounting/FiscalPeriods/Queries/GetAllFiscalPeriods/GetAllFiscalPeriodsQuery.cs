namespace Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Queries.GetAllFiscalPeriods;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Queries.GetPeriodsByYear;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed record GetAllFiscalPeriodsQuery() : IRequest<IReadOnlyList<FiscalPeriodDto>>;

public sealed class GetAllFiscalPeriodsQueryHandler(IApplicationDbContext db) : IRequestHandler<GetAllFiscalPeriodsQuery, IReadOnlyList<FiscalPeriodDto>>
{
    public async Task<IReadOnlyList<FiscalPeriodDto>> Handle(GetAllFiscalPeriodsQuery request, CancellationToken cancellationToken)
    {
        return await db.FiscalPeriods.AsNoTracking()
            .OrderBy(fp => fp.StartDate)
            .Select(fp => new FiscalPeriodDto
            {
                Id = fp.Id,
                PeriodNo = fp.PeriodNo,
                Name = fp.Name,
                StartDate = fp.StartDate,
                EndDate = fp.EndDate,
                Status = fp.Status
            })
            .ToListAsync(cancellationToken);
    }
}
