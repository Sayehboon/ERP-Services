using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Inventories;

namespace Dinawin.Erp.Application.Features.Inventories.InventoryMovements.Commands.CreateInventoryMovement;

/// <summary>
/// پردازش‌کننده دستور ایجاد حرکت انبار
/// </summary>
public sealed class CreateInventoryMovementCommandHandler : IRequestHandler<CreateInventoryMovementCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازش‌کننده دستور ایجاد حرکت انبار
    /// </summary>
    public CreateInventoryMovementCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور ایجاد حرکت انبار
    /// </summary>
    public async Task<Guid> Handle(CreateInventoryMovementCommand request, CancellationToken cancellationToken)
    {
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

        // بررسی وجود مکان (اگر مشخص شده باشد)
        if (request.BinId.HasValue)
        {
            var binExists = await _context.Bins
                .AnyAsync(b => b.Id == request.BinId.Value, cancellationToken);

            if (!binExists)
            {
                throw new ArgumentException($"مکان با شناسه {request.BinId} یافت نشد");
            }
        }

        // بررسی مقدار مثبت
        if (request.Quantity <= 0)
        {
            throw new ArgumentException("مقدار باید بزرگتر از صفر باشد");
        }

        // ایجاد حرکت انبار
        var movement = new InventoryMovement
        {
            Id = Guid.NewGuid(),
            ProductId = request.ProductId,
            WarehouseId = request.WarehouseId,
            BinId = request.BinId,
            MovementType = request.MovementType,
            Quantity = request.Quantity,
            UnitPrice = request.UnitPrice,
            MovementDate = request.MovementDate,
            ReferenceNumber = request.ReferenceNumber,
            ReferenceType = request.ReferenceType,
            ReferenceId = request.ReferenceId,
            Description = request.Description,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.InventoryMovements.Add(movement);

        // به‌روزرسانی موجودی انبار و دریافت موجودی نهایی برای ثبت در حرکت
        var finalQuantity = await UpdateInventoryQuantity(request.ProductId, request.WarehouseId,
            request.MovementType, request.Quantity, cancellationToken);

        movement.BalanceQuantity = finalQuantity;

        await _context.SaveChangesAsync(cancellationToken);

        return movement.Id;
    }

    /// <summary>
    /// به‌روزرسانی مقدار موجودی (جدول اصلی inventory)
    /// </summary>
    private async Task<decimal> UpdateInventoryQuantity(
        Guid productId,
        Guid warehouseId,
        string movementType,
        decimal quantity,
        CancellationToken cancellationToken)
    {
        var inventory = await _context.Inventories
            .FirstOrDefaultAsync(i => i.ProductId == productId && i.WarehouseId == warehouseId, cancellationToken);

        if (inventory == null)
        {
            inventory = new Inventory
            {
                ProductId = productId,
                WarehouseId = warehouseId,
                Quantity = 0,
                MinStockAlert = 0,
                CreatedAt = DateTime.UtcNow
            };
            _context.Inventories.Add(inventory);
        }

        switch (movementType.ToLower())
        {
            case "in":
            case "receipt":
            case "purchase":
            case "transfer_in":
                inventory.Quantity += quantity;
                break;
            case "out":
            case "issue":
            case "sale":
            case "transfer_out":
                inventory.Quantity -= quantity;
                break;
            case "adjustment":
                inventory.Quantity = quantity;
                break;
        }

        if (inventory.Quantity < 0)
        {
            throw new InvalidOperationException("موجودی نمی‌تواند منفی باشد");
        }

        inventory.UpdatedAt = DateTime.UtcNow;
        return inventory.Quantity;
    }
}
