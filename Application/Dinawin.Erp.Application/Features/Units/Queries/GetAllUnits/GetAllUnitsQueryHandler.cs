using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Units.Queries.GetAllUnits;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست واحدهای اندازه‌گیری
/// </summary>
public sealed class GetAllUnitsQueryHandler : IRequestHandler<GetAllUnitsQuery, IEnumerable<UnitDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست واحدهای اندازه‌گیری
    /// </summary>
    public GetAllUnitsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست واحدهای اندازه‌گیری
    /// </summary>
    public async Task<IEnumerable<UnitDto>> Handle(GetAllUnitsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Units
            .Include(u => u.BaseUnit)
            .Include(u => u.Products)
            .Include(u => u.DependentUnits)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(u => 
                u.Name.ToLower().Contains(searchLower) ||
                u.Code.ToLower().Contains(searchLower) ||
                (u.Symbol != null && u.Symbol.ToLower().Contains(searchLower)) ||
                (u.Description != null && u.Description.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس نوع واحد
        if (!string.IsNullOrWhiteSpace(request.UnitType))
        {
            query = query.Where(u => u.UnitType == request.UnitType);
        }

        // فیلتر بر اساس وضعیت فعال/غیرفعال
        if (request.IsActive.HasValue)
        {
            query = query.Where(u => u.IsActive == request.IsActive.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(u => u.SortOrder).ThenBy(u => u.Name);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var units = await query.ToListAsync(cancellationToken);
        
        return units.Select(u => new UnitDto
        {
            Id = u.Id,
            Name = u.Name,
            Code = u.Code,
            Symbol = u.Symbol,
            Description = u.Description,
            UnitType = u.UnitType,
            ConversionFactor = u.ConversionFactor,
            BaseUnitId = u.BaseUnitId,
            BaseUnitName = u.BaseUnit?.Name,
            IsActive = u.IsActive,
            SortOrder = u.SortOrder,
            ProductCount = u.Products?.Count ?? 0,
            DependentUnitCount = u.DependentUnits?.Count ?? 0,
            CreatedAt = u.CreatedAt,
            UpdatedAt = u.UpdatedAt
        });
    }
}
