using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventories.InventoryMovements.Queries.GetAllInventoryMovements;

/// <summary>
/// مدیریت‌کننده پرس‌وجو لیست حرکات موجودی
/// </summary>
public sealed class GetAllInventoryMovementsQueryHandler : IRequestHandler<GetAllInventoryMovementsQuery, IEnumerable<InventoryMovementDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو لیست حرکات موجودی
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetAllInventoryMovementsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو لیست حرکات موجودی
    /// </summary>
    public async Task<IEnumerable<InventoryMovementDto>> Handle(GetAllInventoryMovementsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.InventoryMovements
            .Include(im => im.Product)
            .Include(im => im.Warehouse)
            .Include(im => im.Bin)
            .AsQueryable();

        // اعمال فیلترها
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(im => 
                im.Product.Name.ToLower().Contains(searchTerm) ||
                im.Product.Code.ToLower().Contains(searchTerm) ||
                im.Warehouse.Name.ToLower().Contains(searchTerm) ||
                (im.Bin != null && im.Bin.Name.ToLower().Contains(searchTerm)) ||
                im.MovementType.ToLower().Contains(searchTerm) ||
                (im.ReferenceNumber != null && im.ReferenceNumber.ToLower().Contains(searchTerm)) ||
                (im.Description != null && im.Description.ToLower().Contains(searchTerm)));
        }

        if (request.ProductId.HasValue)
        {
            query = query.Where(im => im.ProductId == request.ProductId.Value);
        }

        if (request.WarehouseId.HasValue)
        {
            query = query.Where(im => im.WarehouseId == request.WarehouseId.Value);
        }

        if (request.BinId.HasValue)
        {
            query = query.Where(im => im.BinId == request.BinId.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.MovementType))
        {
            query = query.Where(im => im.MovementType == request.MovementType);
        }

        if (request.FromDate.HasValue)
        {
            query = query.Where(im => im.MovementDate >= request.FromDate.Value);
        }

        if (request.ToDate.HasValue)
        {
            query = query.Where(im => im.MovementDate <= request.ToDate.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.ReferenceType))
        {
            query = query.Where(im => im.ReferenceType == request.ReferenceType);
        }

        // مرتب‌سازی
        query = query.OrderByDescending(im => im.MovementDate)
                    .ThenByDescending(im => im.CreatedAt);

        // صفحه‌بندی
        if (request.Page > 0 && request.PageSize > 0)
        {
            query = query.Skip((request.Page - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        var movements = await query.ToListAsync(cancellationToken);

        return movements.Select(im => new InventoryMovementDto
        {
            Id = im.Id,
            ProductId = im.ProductId,
            ProductName = im.Product.Name,
            ProductCode = im.Product.Code,
            WarehouseId = im.WarehouseId,
            WarehouseName = im.Warehouse.Name,
            BinId = im.BinId,
            BinName = im.Bin?.Name,
            MovementType = im.MovementType,
            Quantity = im.Quantity,
            Unit = im.Unit,
            UnitPrice = im.UnitPrice,
            TotalPrice = im.TotalPrice,
            MovementDate = im.MovementDate,
            ReferenceNumber = im.ReferenceNumber,
            ReferenceType = im.ReferenceType,
            ReferenceId = im.ReferenceId,
            Description = im.Description,
            CreatedAt = im.CreatedAt,
            UpdatedAt = im.UpdatedAt,
            CreatedBy = im.CreatedBy,
            UpdatedBy = im.UpdatedBy
        });
    }
}
