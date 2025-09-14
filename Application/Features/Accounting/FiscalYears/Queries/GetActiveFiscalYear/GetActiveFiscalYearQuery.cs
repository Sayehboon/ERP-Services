namespace Dinawin.Erp.Application.Features.Accounting.FiscalYears.Queries.GetActiveFiscalYear;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Accounting.FiscalYears.Queries.GetAllFiscalYears;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// پرس‌وجو برای دریافت سال مالی فعال
/// </summary>
public sealed record GetActiveFiscalYearQuery() : IRequest<FiscalYearDto>;

/// <summary>
/// پردازشگر پرس‌وجو دریافت سال مالی فعال
/// </summary>
public sealed class GetActiveFiscalYearQueryHandler : IRequestHandler<GetActiveFiscalYearQuery, FiscalYearDto>
{
    private readonly IApplicationDbContext _db;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    public GetActiveFiscalYearQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<FiscalYearDto> Handle(GetActiveFiscalYearQuery request, CancellationToken cancellationToken)
    {
        var fy = await _db.FiscalYears.AsNoTracking()
            .Where(x => x.IsActive)
            .OrderByDescending(x => x.YearStart)
            .FirstOrDefaultAsync(cancellationToken);
        if (fy == null) return null;
        return new FiscalYearDto
        {
            Id = fy.Id,
            Code = fy.Code,
            YearStart = fy.YearStart,
            YearEnd = fy.YearEnd,
            IsActive = fy.IsActive
        };
    }
}


