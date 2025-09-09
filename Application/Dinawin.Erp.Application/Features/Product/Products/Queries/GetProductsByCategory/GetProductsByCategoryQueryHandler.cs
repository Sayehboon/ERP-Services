using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Product.Products.Queries.GetAllProducts;

namespace Dinawin.Erp.Application.Features.Product.Products.Queries.GetProductsByCategory;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت محصولات یک دسته‌بندی
/// </summary>
public sealed class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, IEnumerable<ProductDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت محصولات یک دسته‌بندی
    /// </summary>
    public GetProductsByCategoryQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت محصولات یک دسته‌بندی
    /// </summary>
    public async Task<IEnumerable<ProductDto>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .Include(p => p.Model)
            .Include(p => p.Trim)
            .Include(p => p.Year)
            .Include(p => p.Unit)
            .Include(p => p.Uom)
            .Where(p => p.CategoryId == request.CategoryId)
            .AsQueryable();

        // فیلتر بر اساس برند
        if (request.BrandId.HasValue)
        {
            query = query.Where(p => p.BrandId == request.BrandId.Value);
        }

        // فیلتر بر اساس مدل
        if (request.ModelId.HasValue)
        {
            query = query.Where(p => p.ModelId == request.ModelId.Value);
        }

        // فیلتر بر اساس تریم
        if (request.TrimId.HasValue)
        {
            query = query.Where(p => p.TrimId == request.TrimId.Value);
        }

        // فیلتر بر اساس سال
        if (request.YearId.HasValue)
        {
            query = query.Where(p => p.YearId == request.YearId.Value);
        }

        // فیلتر بر اساس نوع محصول
        if (!string.IsNullOrWhiteSpace(request.ProductType))
        {
            if (Enum.TryParse<ProductType>(request.ProductType, out var productType))
            {
                query = query.Where(p => p.Type == productType);
            }
        }

        // فیلتر بر اساس وضعیت فعال/غیرفعال
        if (request.IsActive.HasValue)
        {
            query = query.Where(p => p.IsActive == request.IsActive.Value);
        }

        // جستجو در نام و کد محصول
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(p => 
                p.Name.ToLower().Contains(searchLower) ||
                p.Sku.ToLower().Contains(searchLower));
        }

        // مرتب‌سازی
        query = query.OrderBy(p => p.Name);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var products = await query.ToListAsync(cancellationToken);
        
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }
}
