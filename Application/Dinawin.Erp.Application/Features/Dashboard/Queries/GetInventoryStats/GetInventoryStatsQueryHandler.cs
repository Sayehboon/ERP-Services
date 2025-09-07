using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetInventoryStats;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت آمار موجودی
/// </summary>
public sealed class GetInventoryStatsQueryHandler : IRequestHandler<GetInventoryStatsQuery, InventoryStatsDto>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت آمار موجودی
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetInventoryStatsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت آمار موجودی
    /// </summary>
    public async Task<InventoryStatsDto> Handle(GetInventoryStatsQuery request, CancellationToken cancellationToken)
    {
        var inventoryQuery = _context.Inventory
            .Include(i => i.Product)
            .ThenInclude(p => p.Category)
            .Include(i => i.Warehouse)
            .AsQueryable();

        // اعمال فیلترها
        if (request.WarehouseId.HasValue)
        {
            inventoryQuery = inventoryQuery.Where(i => i.WarehouseId == request.WarehouseId.Value);
        }

        if (request.CategoryId.HasValue)
        {
            inventoryQuery = inventoryQuery.Where(i => i.Product.CategoryId == request.CategoryId.Value);
        }

        if (request.ProductId.HasValue)
        {
            inventoryQuery = inventoryQuery.Where(i => i.ProductId == request.ProductId.Value);
        }

        // محاسبه آمار کلی
        var totalProducts = await inventoryQuery.CountAsync(cancellationToken);
        var inStockProducts = await inventoryQuery.CountAsync(i => i.Quantity > 0, cancellationToken);
        var lowStockProducts = await inventoryQuery.CountAsync(i => i.Quantity <= i.ReorderLevel && i.Quantity > 0, cancellationToken);
        var outOfStockProducts = await inventoryQuery.CountAsync(i => i.Quantity == 0, cancellationToken);
        var totalInventoryValue = await inventoryQuery.SumAsync(i => i.Quantity * i.UnitCost, cancellationToken);

        var totalWarehouses = await _context.Warehouses.CountAsync(cancellationToken);
        var totalBins = await _context.Bins.CountAsync(cancellationToken);

        // آمار بر اساس دسته‌بندی
        var categoryStats = await inventoryQuery
            .GroupBy(i => new { i.Product.CategoryId, i.Product.Category.Name })
            .Select(g => new CategoryInventoryStatsDto
            {
                CategoryId = g.Key.CategoryId,
                CategoryName = g.Key.Name,
                ProductCount = g.Count(),
                TotalQuantity = g.Sum(i => i.Quantity),
                InventoryValue = g.Sum(i => i.Quantity * i.UnitCost)
            })
            .ToListAsync(cancellationToken);

        var totalValue = categoryStats.Sum(c => c.InventoryValue);
        foreach (var stat in categoryStats)
        {
            stat.Percentage = totalValue > 0 ? (stat.InventoryValue / totalValue) * 100 : 0;
        }

        // آمار بر اساس انبار
        var warehouseStats = await inventoryQuery
            .GroupBy(i => new { i.WarehouseId, i.Warehouse.Name })
            .Select(g => new WarehouseInventoryStatsDto
            {
                WarehouseId = g.Key.WarehouseId,
                WarehouseName = g.Key.Name,
                ProductCount = g.Count(),
                TotalQuantity = g.Sum(i => i.Quantity),
                InventoryValue = g.Sum(i => i.Quantity * i.UnitCost)
            })
            .ToListAsync(cancellationToken);

        foreach (var stat in warehouseStats)
        {
            stat.Percentage = totalValue > 0 ? (stat.InventoryValue / totalValue) * 100 : 0;
        }

        // محصولات با موجودی کم
        var lowStockProductsList = await inventoryQuery
            .Where(i => i.Quantity <= i.ReorderLevel && i.Quantity > 0)
            .Select(i => new LowStockProductDto
            {
                ProductId = i.ProductId,
                ProductName = i.Product.Name,
                ProductCode = i.Product.Code,
                CurrentQuantity = i.Quantity,
                ReorderLevel = i.ReorderLevel,
                WarehouseName = i.Warehouse.Name,
                CategoryName = i.Product.Category.Name
            })
            .OrderBy(p => p.CurrentQuantity)
            .Take(20)
            .ToListAsync(cancellationToken);

        return new InventoryStatsDto
        {
            TotalProducts = totalProducts,
            InStockProducts = inStockProducts,
            LowStockProducts = lowStockProducts,
            OutOfStockProducts = outOfStockProducts,
            TotalInventoryValue = totalInventoryValue,
            TotalWarehouses = totalWarehouses,
            TotalBins = totalBins,
            CategoryStats = categoryStats,
            WarehouseStats = warehouseStats,
            LowStockProducts = lowStockProductsList
        };
    }
}
