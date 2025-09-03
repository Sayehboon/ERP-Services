using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Products.Queries.Dtos;

namespace Dinawin.Erp.Application.Features.Brands.Queries.GetAllBrands;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست برندها
/// Get all brands query handler
/// </summary>
public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, IEnumerable<BrandDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست برندها
    /// Get all brands query handler constructor
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    /// <param name="mapper">نگاشت‌کننده</param>
    public GetAllBrandsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست برندها
    /// Handle get all brands query
    /// </summary>
    /// <param name="request">درخواست لیست برندها</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>لیست برندها</returns>
    public async Task<IEnumerable<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Brands
            .Include(b => b.Products)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        // Filter by search term
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(b => 
                b.Name.ToLower().Contains(searchLower) ||
                (b.Description != null && b.Description.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس وضعیت فعال/غیرفعال
        // Filter by active status
        if (request.IsActive.HasValue)
        {
            query = query.Where(b => b.IsActive == request.IsActive.Value);
        }

        // مرتب‌سازی
        // Ordering
        query = query.OrderBy(b => b.SortOrder).ThenBy(b => b.Name);

        // صفحه‌بندی
        // Pagination
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var brands = await query.ToListAsync(cancellationToken);
        
        return _mapper.Map<IEnumerable<BrandDto>>(brands);
    }
}
