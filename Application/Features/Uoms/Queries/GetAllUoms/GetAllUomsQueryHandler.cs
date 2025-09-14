using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Uoms.Queries.GetAllUoms;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست واحدهای اندازه‌گیری
/// </summary>
public sealed class GetAllUomsQueryHandler : IRequestHandler<GetAllUomsQuery, IEnumerable<UomDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست واحدهای اندازه‌گیری
    /// </summary>
    public GetAllUomsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست واحدهای اندازه‌گیری
    /// </summary>
    public async Task<IEnumerable<UomDto>> Handle(GetAllUomsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.UnitsOfMeasures.AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(u => 
                u.Name.ToLower().Contains(searchLower) ||
                u.Code.ToLower().Contains(searchLower) ||
                (u.Symbol != null && u.Symbol.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس نوع واحد اندازه‌گیری
        if (!string.IsNullOrWhiteSpace(request.UomType))
        {
            query = query.Where(u => u.UomType == request.UomType);
        }

        // فیلتر بر اساس وضعیت فعال بودن
        if (request.IsActive.HasValue)
        {
            query = query.Where(u => u.IsActive == request.IsActive.Value);
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
        
        return uoms.Select(u => new UomDto
        {
            Id = u.Id,
            Name = u.Name,
            Code = u.Code,
            Symbol = u.Symbol,
            UomType = u.UomType,
            Description = u.Description,
            IsActive = u.IsActive,
            CreatedAt = u.CreatedAt,
            UpdatedAt = u.UpdatedAt,
            CreatedBy = u.CreatedBy,
            UpdatedBy = u.UpdatedBy
        });
    }
}
