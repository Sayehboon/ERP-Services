using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Products.Queries.Dtos;

namespace Dinawin.Erp.Application.Features.Products.Queries.GetAllProducts;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست کالاها
/// Get all products query handler
/// </summary>
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست کالاها
    /// Get all products query handler constructor
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    /// <param name="mapper">نگاشت‌کننده</param>
    public GetAllProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست کالاها
    /// Handle get all products query
    /// </summary>
    /// <param name="request">درخواست لیست کالاها</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>لیست کالاها</returns>
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .Include(p => p.BaseUom)
            .Include(p => p.Inventories)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        // Filter by search term
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(p => 
                p.Name.ToLower().Contains(searchLower) ||
                p.Sku.ToLower().Contains(searchLower) ||
                (p.Brand != null && p.Brand.Name.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس برند
        // Filter by brand
        if (request.BrandId.HasValue)
        {
            query = query.Where(p => p.BrandId == request.BrandId.Value);
        }

        // فیلتر بر اساس دسته‌بندی
        // Filter by category
        if (request.CategoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == request.CategoryId.Value);
        }

        // فیلتر بر اساس وضعیت فعال/غیرفعال
        // Filter by active status
        if (request.IsActive.HasValue)
        {
            query = query.Where(p => p.IsActive == request.IsActive.Value);
        }

        // مرتب‌سازی
        // Ordering
        query = query.OrderBy(p => p.Name);

        // صفحه‌بندی
        // Pagination
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var products = await query.ToListAsync(cancellationToken);
        
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }
}
