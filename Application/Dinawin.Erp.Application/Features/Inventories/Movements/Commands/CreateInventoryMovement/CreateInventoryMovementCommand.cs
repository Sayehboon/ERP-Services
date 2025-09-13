namespace Dinawin.Erp.Application.Features.Inventories.Movements.Commands.CreateInventoryMovement;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Inventories;
using Dinawin.Erp.Domain.Enums;
using Dinawin.Erp.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// فرمان ایجاد حرکت موجودی جدید
/// Create inventory movement command
/// </summary>
public record CreateInventoryMovementCommand(
    Guid ProductId,
    Guid WarehouseId,
    string Type,
    decimal Quantity,
    decimal? UnitCost,
    string Reason,
    string? ReferenceNumber = null,
    string? Notes = null,
    DateTime? MovementDate = null
) : IRequest<Guid>;

/// <summary>
/// هندلر فرمان ایجاد حرکت موجودی جدید
/// Handler for CreateInventoryMovementCommand
/// </summary>
public class CreateInventoryMovementCommandHandler : IRequestHandler<CreateInventoryMovementCommand, Guid>
{
    private readonly IApplicationDbContext _db;
    public CreateInventoryMovementCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<Guid> Handle(CreateInventoryMovementCommand request, CancellationToken cancellationToken)
    {
        // Get current inventory balance
        var inventory = await _db.Inventories
            .FirstOrDefaultAsync(i => i.ProductId == request.ProductId && i.WarehouseId == request.WarehouseId, cancellationToken);

        var balanceBefore = inventory?.Quantity ?? 0;
        var balanceAfter = balanceBefore + request.Quantity;

        // Create movement
        var movement = new InventoryMovement
        {
            Id = Guid.NewGuid(),
            ProductId = request.ProductId,
            WarehouseId = request.WarehouseId,
            Type = request.Type,
            Quantity = request.Quantity,
            UnitCost = request.UnitCost,
            TotalValue = request.UnitCost.HasValue ? request.UnitCost.Value * request.Quantity : null,
            BalanceBefore = balanceBefore,
            BalanceAfter = balanceAfter,
            ReferenceNumber = request.ReferenceNumber,
            Reason = request.Reason,
            Notes = request.Notes,
            MovementDate = request.MovementDate ?? DateTime.UtcNow
        };

        _db.InventoryMovements.Add(movement);

        // Update inventory
        if (inventory == null)
        {
            inventory = new Inventory
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                WarehouseId = request.WarehouseId,
                Quantity = balanceAfter,
                ReservedQuantity = 0,
                MinStockAlert = 0,
                MaxStockLevel = 0,
                ReorderPoint = 0,
                SafetyStock = 0
            };
            _db.Inventories.Add(inventory);
        }
        else
        {
            inventory.Quantity = balanceAfter;
        }

        await _db.SaveChangesAsync(cancellationToken);
        return movement.Id;
    }
}
