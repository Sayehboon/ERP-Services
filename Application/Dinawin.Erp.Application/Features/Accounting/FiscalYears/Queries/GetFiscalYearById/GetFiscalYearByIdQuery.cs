namespace Dinawin.Erp.Application.Features.Accounting.FiscalYears.Queries.GetFiscalYearById;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Accounting.FiscalYears.Queries.GetAllFiscalYears;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// پرس‌وجو برای دریافت سال مالی بر اساس شناسه
/// </summary>
public sealed record GetFiscalYearByIdQuery(Guid Id) : IRequest<FiscalYearDto?>;

/// <summary>
/// پردازشگر پرس‌وجو دریافت سال مالی بر اساس شناسه
/// </summary>
public sealed class GetFiscalYearByIdQueryHandler : IRequestHandler<GetFiscalYearByIdQuery, FiscalYearDto?>
{
    private readonly IApplicationDbContext _db;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    public GetFiscalYearByIdQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<FiscalYearDto?> Handle(GetFiscalYearByIdQuery request, CancellationToken cancellationToken)
    {
        var fy = await _db.FiscalYears.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
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


