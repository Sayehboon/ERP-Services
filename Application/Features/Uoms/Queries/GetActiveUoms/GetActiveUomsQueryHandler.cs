using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Products;

namespace Dinawin.Erp.Application.Features.Uoms.Queries.GetActiveUoms;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت واحدهای اندازه‌گیری فعال
/// </summary>
public sealed class GetActiveUomsQueryHandler : IRequestHandler<GetActiveUomsQuery, IEnumerable<UomDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت واحدهای اندازه‌گیری فعال
    /// </summary>
    public GetActiveUomsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت واحدهای اندازه‌گیری فعال
    /// </summary>
    public async Task<IEnumerable<UomDto>> Handle(GetActiveUomsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.UnitsOfMeasures
            .Include(u => u.BaseUom)
            .Where(u => u.IsActive)
            .AsQueryable();

        // فیلتر بر اساس نوع
        if (!string.IsNullOrWhiteSpace(request.Type))
        {
            if (Enum.TryParse<UnitType>(request.Type, true, out var unitType))
            {
                query = query.Where(u => u.Type == unitType);
            }
        }

        // جستجو در نام، نماد و کد
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(u => 
                (u.Name != null && u.Name.ToLower().Contains(searchLower)) ||
                (u.Symbol != null && u.Symbol.ToLower().Contains(searchLower)) ||
                (u.Code != null && u.Code.ToLower().Contains(searchLower)));
        }

        // مرتب‌سازی
        query = query.OrderBy(u => u.Name);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var uoms = await query.ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<UomDto>>(uoms);
    }
}
