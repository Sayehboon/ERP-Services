using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Queries.GetInventoryByProduct;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت موجودی محصول
/// </summary>
public sealed class GetInventoryByProductQueryHandler : IRequestHandler<GetInventoryByProductQuery, ProductInventoryDto>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت موجودی محصول
    /// </summary>
    public GetInventoryByProductQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت موجودی محصول
    /// </summary>
    public async Task<ProductInventoryDto> Handle(GetInventoryByProductQuery request, CancellationToken cancellationToken)
    {
        // بررسی وجود محصول
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);

        if (product == null)
        {
            return null;
        }

        // دریافت موجودی‌های محصول
        var inventoryQuery = _context.Inventories
            .Include(i => i.Warehouse)
            .Where(i => i.ProductId == request.ProductId)
            .AsQueryable();

        // فیلتر بر اساس انبار
        if (request.WarehouseId.HasValue)
        {
            inventoryQuery = inventoryQuery.Where(i => i.WarehouseId == request.WarehouseId.Value);
        }

        var inventories = await inventoryQuery.ToListAsync(cancellationToken);

        if (!inventories.Any())
        {
            return new ProductInventoryDto
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductCode = product.Sku,
                TotalQuantity = 0,
                ReservedQuantity = 0,
                AvailableQuantity = 0,
                InTransitQuantity = 0,
                MinStockLevel = product.MinStockLevel,
                MaxStockLevel = product.MaxStockLevel,
                ReorderPoint = product.ReorderPoint,
                IsLowStock = true,
                IsOverStock = false,
                Unit = "عدد"
            };
        }

        // محاسبه آمار کلی
        var totalQuantity = inventories.Sum(i => i.Quantity);
        var reservedQuantity = inventories.Sum(i => i.ReservedQuantity);
        var availableQuantity = totalQuantity - reservedQuantity;
        // InTransitQuantity property does not exist in Inventory entity
        var inTransitQuantity = 0m;

        var result = new ProductInventoryDto
        {
            ProductId = product.Id,
            ProductName = product.Name,
            ProductCode = product.Sku,
            TotalQuantity = totalQuantity,
            ReservedQuantity = reservedQuantity,
            AvailableQuantity = availableQuantity,
            InTransitQuantity = inTransitQuantity,
            MinStockLevel = product.MinStockLevel,
            MaxStockLevel = product.MaxStockLevel,
            ReorderPoint = product.ReorderPoint,
            IsLowStock = totalQuantity <= product.MinStockLevel,
            IsOverStock = totalQuantity >= product.MaxStockLevel,
            Unit = "عدد",
            LastUpdated = inventories.Max(i => i.UpdatedAt),
            WarehouseInventories = inventories.Select(i => new WarehouseInventoryDto
            {
                WarehouseId = i.WarehouseId,
                WarehouseName = i.Warehouse?.Name ?? "نامشخص",
                Quantity = i.Quantity,
                ReservedQuantity = i.ReservedQuantity,
                AvailableQuantity = i.Quantity - i.ReservedQuantity,
                LastUpdated = i.UpdatedAt
            }).ToList()
        };

        return result;
    }
}
