namespace Dinawin.Erp.Application.Features.Accounting.FiscalYears.Queries.GetAllFiscalYears;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetAllFiscalYearsQuery() : IRequest<IReadOnlyList<FiscalYearDto>>;

public class FiscalYearDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public DateTime YearStart { get; set; }
    public DateTime YearEnd { get; set; }
    public bool IsActive { get; set; }
}

public class GetAllFiscalYearsQueryHandler : IRequestHandler<GetAllFiscalYearsQuery, IReadOnlyList<FiscalYearDto>>
{
    private readonly IApplicationDbContext _db;
    public GetAllFiscalYearsQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<FiscalYearDto>> Handle(GetAllFiscalYearsQuery request, CancellationToken cancellationToken)
    {
        return await _db.FiscalYears.AsNoTracking()
            .Where(fy => fy.IsActive)
            .OrderByDescending(fy => fy.YearStart)
            .Select(fy => new FiscalYearDto
            {
                Id = fy.Id,
                Code = fy.Code,
                YearStart = fy.YearStart,
                YearEnd = fy.YearEnd,
                IsActive = fy.IsActive
            })
            .ToListAsync(cancellationToken);
    }
}
