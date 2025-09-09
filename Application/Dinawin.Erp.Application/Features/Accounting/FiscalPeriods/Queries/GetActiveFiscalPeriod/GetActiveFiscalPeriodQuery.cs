namespace Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Queries.GetActiveFiscalPeriod;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Queries.GetPeriodsByYear;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed record GetActiveFiscalPeriodQuery(Guid FiscalYearId) : IRequest<FiscalPeriodDto?>;

public sealed class GetActiveFiscalPeriodQueryHandler(IApplicationDbContext db) : IRequestHandler<GetActiveFiscalPeriodQuery, FiscalPeriodDto?>
{
    public async Task<FiscalPeriodDto?> Handle(GetActiveFiscalPeriodQuery request, CancellationToken cancellationToken)
    {
        var fp = await db.FiscalPeriods.AsNoTracking()
            .Where(x => x.FiscalYearId == request.FiscalYearId && x.Status == "open")
            .OrderBy(x => x.PeriodNo)
            .FirstOrDefaultAsync(cancellationToken);
        if (fp == null) return null;
        return new FiscalPeriodDto
        {
            Id = fp.Id,
            PeriodNo = fp.PeriodNo,
            Name = fp.Name,
            StartDate = fp.StartDate,
            EndDate = fp.EndDate,
            Status = fp.Status
        };
    }
}


