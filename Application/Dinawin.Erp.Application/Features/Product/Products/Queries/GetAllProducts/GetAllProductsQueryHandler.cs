using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Product.Products.Queries.GetAllProducts;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست محصولات
/// </summary>
public sealed class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست محصولات
    /// </summary>
    public GetAllProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست محصولات
    /// </summary>
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .Include(p => p.Model)
            .Include(p => p.Trim)
            .Include(p => p.Year)
            .Include(p => p.Unit)
            .Include(p => p.Uom)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(p => 
                p.Name.ToLower().Contains(searchLower) ||
                p.Code.ToLower().Contains(searchLower) ||
                (p.Brand != null && p.Brand.Name.ToLower().Contains(searchLower)) ||
                (p.Category != null && p.Category.Name.ToLower().Contains(searchLower)) ||
                (p.Model != null && p.Model.Name.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس برند
        if (request.BrandId.HasValue)
        {
            query = query.Where(p => p.BrandId == request.BrandId.Value);
        }

        // فیلتر بر اساس دسته‌بندی
        if (request.CategoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == request.CategoryId.Value);
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

        // فیلتر بر اساس واحد
        if (request.UnitId.HasValue)
        {
            query = query.Where(p => p.UnitId == request.UnitId.Value);
        }

        // فیلتر بر اساس UOM
        if (request.UomId.HasValue)
        {
            query = query.Where(p => p.UomId == request.UomId.Value);
        }

        // فیلتر بر اساس نوع محصول
        if (!string.IsNullOrWhiteSpace(request.ProductType))
        {
            query = query.Where(p => p.ProductType == request.ProductType);
        }

        // فیلتر بر اساس وضعیت
        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            query = query.Where(p => p.Status == request.Status);
        }

        // فیلتر بر اساس رنگ
        if (!string.IsNullOrWhiteSpace(request.Color))
        {
            query = query.Where(p => p.Color == request.Color);
        }

        // فیلتر بر اساس قابلیت فروش
        if (request.IsSellable.HasValue)
        {
            query = query.Where(p => p.IsSellable == request.IsSellable.Value);
        }

        // فیلتر بر اساس قابلیت خرید
        if (request.IsPurchasable.HasValue)
        {
            query = query.Where(p => p.IsPurchasable == request.IsPurchasable.Value);
        }

        // فیلتر بر اساس قابلیت تولید
        if (request.IsManufacturable.HasValue)
        {
            query = query.Where(p => p.IsManufacturable == request.IsManufacturable.Value);
        }

        // فیلتر بر اساس قیمت خرید
        if (request.MinPurchasePrice.HasValue)
        {
            query = query.Where(p => p.PurchasePrice >= request.MinPurchasePrice.Value);
        }

        if (request.MaxPurchasePrice.HasValue)
        {
            query = query.Where(p => p.PurchasePrice <= request.MaxPurchasePrice.Value);
        }

        // فیلتر بر اساس قیمت فروش
        if (request.MinSalePrice.HasValue)
        {
            query = query.Where(p => p.SalePrice >= request.MinSalePrice.Value);
        }

        if (request.MaxSalePrice.HasValue)
        {
            query = query.Where(p => p.SalePrice <= request.MaxSalePrice.Value);
        }

        // فیلتر بر اساس موجودی
        if (request.MinStock.HasValue)
        {
            query = query.Where(p => p.CurrentStock >= request.MinStock.Value);
        }

        if (request.MaxStock.HasValue)
        {
            query = query.Where(p => p.CurrentStock <= request.MaxStock.Value);
        }

        // فیلتر بر اساس موجودی کم
        if (request.IsLowStock.HasValue && request.IsLowStock.Value)
        {
            query = query.Where(p => p.CurrentStock <= p.MinStock);
        }

        // مرتب‌سازی
        query = query.OrderByDescending(p => p.CreatedAt);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var products = await query.ToListAsync(cancellationToken);
        
        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Code = p.Code,
            BrandId = p.BrandId,
            BrandName = p.Brand?.Name,
            CategoryId = p.CategoryId,
            CategoryName = p.Category?.Name,
            ModelId = p.ModelId,
            ModelName = p.Model?.Name,
            TrimId = p.TrimId,
            TrimName = p.Trim?.Name,
            YearId = p.YearId,
            Year = p.Year?.Year,
            UnitId = p.UnitId,
            UnitName = p.Unit?.Name,
            UomId = p.UomId,
            UomName = p.Uom?.Name,
            Description = p.Description,
            PurchasePrice = p.PurchasePrice,
            SalePrice = p.SalePrice,
            WholesalePrice = p.WholesalePrice,
            MinStock = p.MinStock,
            MaxStock = p.MaxStock,
            CurrentStock = p.CurrentStock,
            Weight = p.Weight,
            Dimensions = p.Dimensions,
            Color = p.Color,
            ProductType = p.ProductType,
            Status = p.Status,
            IsSellable = p.IsSellable,
            IsPurchasable = p.IsPurchasable,
            IsManufacturable = p.IsManufacturable,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt,
            CreatedBy = p.CreatedBy,
            UpdatedBy = p.UpdatedBy
        });
    }
}