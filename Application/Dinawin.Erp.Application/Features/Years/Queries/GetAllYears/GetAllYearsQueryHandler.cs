using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Years.Queries.GetAllYears;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست سال‌ها
/// </summary>
public sealed class GetAllYearsQueryHandler : IRequestHandler<GetAllYearsQuery, IEnumerable<YearDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست سال‌ها
    /// </summary>
    public GetAllYearsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست سال‌ها
    /// </summary>
    public async Task<IEnumerable<YearDto>> Handle(GetAllYearsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Years.AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(y => 
                y.YearValue.ToString().Contains(searchLower) ||
                (y.Description != null && y.Description.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس وضعیت فعال/غیرفعال
        if (request.IsActive.HasValue)
        {
            query = query.Where(y => y.IsActive == request.IsActive.Value);
        }

        // فیلتر بر اساس بازه سال
        if (request.YearFrom.HasValue)
        {
            query = query.Where(y => y.YearValue >= request.YearFrom.Value);
        }

        if (request.YearTo.HasValue)
        {
            query = query.Where(y => y.YearValue <= request.YearTo.Value);
        }

        // مرتب‌سازی
        query = query.OrderByDescending(y => y.YearValue);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var years = await query.ToListAsync(cancellationToken);
        
        return years.Select(y => new YearDto
        {
            Id = y.Id,
            Year = y.YearValue,
            Description = y.Description,
            IsActive = y.IsActive,
            SortOrder = 0,
            ProductCount = 0,
            CreatedAt = y.CreatedAt,
            UpdatedAt = y.UpdatedAt
        });
    }
}
