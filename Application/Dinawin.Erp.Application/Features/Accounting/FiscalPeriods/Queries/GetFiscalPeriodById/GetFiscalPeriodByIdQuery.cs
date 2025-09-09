namespace Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Queries.GetFiscalPeriodById;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Queries.GetPeriodsByYear;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed record GetFiscalPeriodByIdQuery(Guid Id) : IRequest<FiscalPeriodDto?>;

public sealed class GetFiscalPeriodByIdQueryHandler(IApplicationDbContext db) : IRequestHandler<GetFiscalPeriodByIdQuery, FiscalPeriodDto?>
{
    public async Task<FiscalPeriodDto?> Handle(GetFiscalPeriodByIdQuery request, CancellationToken cancellationToken)
    {
        var fp = await db.FiscalPeriods.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
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


