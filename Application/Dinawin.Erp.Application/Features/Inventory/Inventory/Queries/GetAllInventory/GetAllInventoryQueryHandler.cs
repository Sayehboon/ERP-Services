using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventory.Inventory.Queries.GetAllInventory;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست موجودی‌ها
/// </summary>
public sealed class GetAllInventoryQueryHandler : IRequestHandler<GetAllInventoryQuery, IEnumerable<InventoryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست موجودی‌ها
    /// </summary>
    public GetAllInventoryQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست موجودی‌ها
    /// </summary>
    public async Task<IEnumerable<InventoryDto>> Handle(GetAllInventoryQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Inventory
            .Include(i => i.Product)
            .Include(i => i.Warehouse)
            .Include(i => i.Bin)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(i => 
                i.Product.Name.ToLower().Contains(searchLower) ||
                i.Product.Code.ToLower().Contains(searchLower) ||
                i.Warehouse.Name.ToLower().Contains(searchLower) ||
                (i.Bin != null && i.Bin.Name.ToLower().Contains(searchLower)) ||
                (i.SerialNumber != null && i.SerialNumber.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس محصول
        if (request.ProductId.HasValue)
        {
            query = query.Where(i => i.ProductId == request.ProductId.Value);
        }

        // فیلتر بر اساس انبار
        if (request.WarehouseId.HasValue)
        {
            query = query.Where(i => i.WarehouseId == request.WarehouseId.Value);
        }

        // فیلتر بر اساس مکان
        if (request.BinId.HasValue)
        {
            query = query.Where(i => i.BinId == request.BinId.Value);
        }

        // فیلتر موجودی کم
        if (request.LowStock.HasValue && request.LowStock.Value)
        {
            query = query.Where(i => i.Quantity <= i.MinQuantity);
        }

        // فیلتر موجودی منقضی
        if (request.Expired.HasValue && request.Expired.Value)
        {
            query = query.Where(i => i.ExpiryDate.HasValue && i.ExpiryDate.Value < DateTime.UtcNow);
        }

        // مرتب‌سازی
        query = query.OrderBy(i => i.Product.Name).ThenBy(i => i.Warehouse.Name);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var inventory = await query.ToListAsync(cancellationToken);
        
        return inventory.Select(i => new InventoryDto
        {
            Id = i.Id,
            ProductId = i.ProductId,
            ProductName = i.Product.Name,
            ProductCode = i.Product.Code,
            WarehouseId = i.WarehouseId,
            WarehouseName = i.Warehouse.Name,
            BinId = i.BinId,
            BinName = i.Bin?.Name,
            Quantity = i.Quantity,
            ReservedQuantity = i.ReservedQuantity,
            MinQuantity = i.MinQuantity,
            MaxQuantity = i.MaxQuantity,
            UnitPrice = i.UnitPrice,
            ExpiryDate = i.ExpiryDate,
            SerialNumber = i.SerialNumber,
            Description = i.Description,
            CreatedAt = i.CreatedAt,
            UpdatedAt = i.UpdatedAt,
            CreatedBy = i.CreatedBy,
            UpdatedBy = i.UpdatedBy
        });
    }
}
