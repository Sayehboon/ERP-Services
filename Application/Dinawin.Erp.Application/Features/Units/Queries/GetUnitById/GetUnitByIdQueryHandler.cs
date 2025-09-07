using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Units.Queries.GetUnitById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت واحد اندازه‌گیری بر اساس شناسه
/// </summary>
public sealed class GetUnitByIdQueryHandler : IRequestHandler<GetUnitByIdQuery, UnitDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت واحد اندازه‌گیری بر اساس شناسه
    /// </summary>
    public GetUnitByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<UnitDto?> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
    {
        var unit = await _context.Units
            .Include(u => u.BaseUnit)
            .Include(u => u.Products)
            .Include(u => u.DependentUnits)
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (unit == null)
        {
            return null;
        }

        var dto = _mapper.Map<UnitDto>(unit);
        dto.BaseUnitName = unit.BaseUnit?.Name;
        dto.ProductCount = unit.Products?.Count ?? 0;
        dto.DependentUnitCount = unit.DependentUnits?.Count ?? 0;
        return dto;
    }
}
