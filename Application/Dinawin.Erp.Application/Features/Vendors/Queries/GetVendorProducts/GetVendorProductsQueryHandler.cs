using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Vendors.Queries.GetVendorProducts;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت محصولات تامین‌کننده
/// </summary>
public sealed class GetVendorProductsQueryHandler : IRequestHandler<GetVendorProductsQuery, IEnumerable<VendorProductDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت محصولات تامین‌کننده
    /// </summary>
    public GetVendorProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت محصولات تامین‌کننده
    /// </summary>
    public async Task<IEnumerable<VendorProductDto>> Handle(GetVendorProductsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Products
            .Include(p => p.Category)
            .Include(p => p.BaseUom)
            .Where(p => p.IsActive);

        // فیلتر بر اساس وضعیت فعال
        if (request.IsActive.HasValue)
        {
            query = query.Where(p => p.IsActive == request.IsActive.Value);
        }

        // فیلتر بر اساس دسته‌بندی
        if (request.CategoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == request.CategoryId.Value);
        }

        // جستجو در نام یا کد محصول
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(p => p.Name.ToLower().Contains(searchTerm) || 
                                   p.Code.ToLower().Contains(searchTerm));
        }

        var products = await query
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);

        var result = new List<VendorProductDto>();

        foreach (var product in products)
        {
            // محاسبه موجودی فعلی بر اساس موجودی‌های ثبت‌شده
            var currentStock = await _context.Inventories
                .Where(i => i.ProductId == product.Id)
                .SumAsync(i => i.AvailableQuantity, cancellationToken);

            var productDto = new VendorProductDto
            {
                Id = product.Id,
                ProductName = product.Name,
                ProductCode = product.Code ?? string.Empty,
                Description = product.Description,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name,
                UomId = product.BaseUomId,
                UomName = product.BaseUom?.Name,
                PurchasePrice = product.PurchasePrice?.Amount,
                SalePrice = product.SellingPrice?.Amount,
                MinStockLevel = product.MinStockLevel,
                MaxStockLevel = product.MaxStockLevel,
                CurrentStock = currentStock,
                IsActive = product.IsActive,
                IsAvailable = product.IsActive && currentStock > 0,
                LastPurchaseDate = null,
                LastSaleDate = null,
                SalesThisMonth = null,
                SalesLastMonth = null,
                ImageUrl = null,
                Tags = new List<string>(),
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };

            result.Add(productDto);
        }

        return result;
    }
}
