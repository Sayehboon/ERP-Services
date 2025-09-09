using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Inventories.InventoryMovements.Queries.GetAllInventoryMovements;

namespace Dinawin.Erp.Application.Features.Inventories.InventoryMovements.Queries.GetInventoryMovementById;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت حرکت موجودی بر اساس شناسه
/// </summary>
public sealed class GetInventoryMovementByIdQueryHandler : IRequestHandler<GetInventoryMovementByIdQuery, InventoryMovementDto?>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت حرکت موجودی بر اساس شناسه
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetInventoryMovementByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت حرکت موجودی بر اساس شناسه
    /// </summary>
    public async Task<InventoryMovementDto?> Handle(GetInventoryMovementByIdQuery request, CancellationToken cancellationToken)
    {
        var movement = await _context.InventoryMovements
            .Include(im => im.Product)
            .Include(im => im.Warehouse)
            .Include(im => im.Bin)
            .FirstOrDefaultAsync(im => im.Id == request.Id, cancellationToken);

        if (movement == null)
        {
            return null;
        }

        return new InventoryMovementDto
        {
            Id = movement.Id,
            ProductId = movement.ProductId,
            ProductName = movement.Product.Name,
            ProductCode = movement.Product.Code,
            WarehouseId = movement.WarehouseId,
            WarehouseName = movement.Warehouse.Name,
            BinId = movement.BinId,
            BinName = movement.Bin?.Name,
            MovementType = movement.MovementType,
            Quantity = movement.Quantity,
            Unit = movement.Unit,
            UnitPrice = movement.UnitPrice,
            TotalPrice = movement.TotalPrice,
            MovementDate = movement.MovementDate,
            ReferenceNumber = movement.ReferenceNumber,
            ReferenceType = movement.ReferenceType,
            ReferenceId = movement.ReferenceId,
            Description = movement.Description,
            CreatedAt = movement.CreatedAt,
            UpdatedAt = movement.UpdatedAt,
            CreatedBy = movement.CreatedBy,
            UpdatedBy = movement.UpdatedBy
        };
    }
}
