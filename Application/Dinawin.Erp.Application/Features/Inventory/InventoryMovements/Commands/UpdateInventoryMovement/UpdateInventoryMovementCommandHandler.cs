using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventory.InventoryMovements.Commands.UpdateInventoryMovement;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی حرکت موجودی
/// </summary>
public sealed class UpdateInventoryMovementCommandHandler : IRequestHandler<UpdateInventoryMovementCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی حرکت موجودی
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateInventoryMovementCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی حرکت موجودی
    /// </summary>
    public async Task<Guid> Handle(UpdateInventoryMovementCommand request, CancellationToken cancellationToken)
    {
        var movement = await _context.InventoryMovements.FirstOrDefaultAsync(im => im.Id == request.Id, cancellationToken);
        if (movement == null)
        {
            throw new ArgumentException($"حرکت موجودی با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود محصول
        var productExists = await _context.Products
            .AnyAsync(p => p.Id == request.ProductId, cancellationToken);
        if (!productExists)
        {
            throw new ArgumentException($"محصول با شناسه {request.ProductId} یافت نشد");
        }

        // بررسی وجود انبار
        var warehouseExists = await _context.Warehouses
            .AnyAsync(w => w.Id == request.WarehouseId, cancellationToken);
        if (!warehouseExists)
        {
            throw new ArgumentException($"انبار با شناسه {request.WarehouseId} یافت نشد");
        }

        // بررسی وجود مکان (در صورت ارائه)
        if (request.BinId.HasValue)
        {
            var binExists = await _context.Bins
                .AnyAsync(b => b.Id == request.BinId.Value && b.WarehouseId == request.WarehouseId, cancellationToken);
            if (!binExists)
            {
                throw new ArgumentException($"مکان با شناسه {request.BinId} در انبار {request.WarehouseId} یافت نشد");
            }
        }

        movement.ProductId = request.ProductId;
        movement.WarehouseId = request.WarehouseId;
        movement.BinId = request.BinId;
        movement.MovementType = request.MovementType;
        movement.Quantity = request.Quantity;
        movement.Unit = request.Unit;
        movement.UnitPrice = request.UnitPrice;
        movement.TotalPrice = request.TotalPrice;
        movement.MovementDate = request.MovementDate;
        movement.ReferenceNumber = request.ReferenceNumber;
        movement.ReferenceType = request.ReferenceType;
        movement.ReferenceId = request.ReferenceId;
        movement.Description = request.Description;
        movement.UpdatedBy = request.UpdatedBy;
        movement.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return movement.Id;
    }
}
