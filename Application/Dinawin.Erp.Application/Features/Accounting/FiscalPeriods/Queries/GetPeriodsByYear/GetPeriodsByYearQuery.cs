namespace Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Queries.GetPeriodsByYear;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetPeriodsByYearQuery(Guid FiscalYearId) : IRequest<IReadOnlyList<FiscalPeriodDto>>;

public class FiscalPeriodDto
{
    public Guid Id { get; set; }
    public int PeriodNo { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class GetPeriodsByYearQueryHandler : IRequestHandler<GetPeriodsByYearQuery, IReadOnlyList<FiscalPeriodDto>>
{
    private readonly IApplicationDbContext _db;
    public GetPeriodsByYearQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<FiscalPeriodDto>> Handle(GetPeriodsByYearQuery request, CancellationToken cancellationToken)
    {
        return await _db.FiscalPeriods.AsNoTracking()
            .Where(fp => fp.FiscalYearId == request.FiscalYearId)
            .OrderBy(fp => fp.PeriodNo)
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
