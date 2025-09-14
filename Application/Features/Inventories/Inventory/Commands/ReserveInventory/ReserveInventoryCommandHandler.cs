using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Inventories;

namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Commands.ReserveInventory;

/// <summary>
/// پردازش‌کننده دستور رزرو موجودی
/// </summary>
public sealed class ReserveInventoryCommandHandler : IRequestHandler<ReserveInventoryCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازش‌کننده دستور رزرو موجودی
    /// </summary>
    public ReserveInventoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور رزرو موجودی
    /// </summary>
    public async Task<bool> Handle(ReserveInventoryCommand request, CancellationToken cancellationToken)
    {
        // بررسی مقدار مثبت
        if (request.Quantity <= 0)
        {
            throw new ArgumentException("مقدار رزرو باید بزرگتر از صفر باشد");
        }

        // دریافت موجودی
        var inventory = await _context.Inventories
            .FirstOrDefaultAsync(i => i.ProductId == request.ProductId && 
                                    i.WarehouseId == request.WarehouseId && 
                                    i.BinId == request.BinId, cancellationToken);

        if (inventory == null)
        {
            throw new ArgumentException("موجودی برای این محصول در انبار مشخص شده یافت نشد");
        }

        // بررسی موجودی کافی
        if (inventory.QuantityAvailable < request.Quantity)
        {
            throw new InvalidOperationException($"موجودی کافی نیست. موجودی قابل دسترس: {inventory.QuantityAvailable}");
        }

        // رزرو موجودی
        inventory.QuantityReserved += request.Quantity;
        inventory.QuantityAvailable = inventory.QuantityOnHand - inventory.QuantityReserved;
        inventory.UpdatedAt = DateTime.UtcNow;

        // ایجاد رکورد رزرو
        var reservation = new InventoryReservation
        {
            Id = Guid.NewGuid(),
            ProductId = request.ProductId,
            WarehouseId = request.WarehouseId,
            BinId = request.BinId,
            Quantity = request.Quantity,
            ReferenceNumber = request.ReferenceNumber,
            ReferenceType = request.ReferenceType,
            ReferenceId = request.ReferenceId,
            ExpiryDate = request.ExpiryDate,
            Description = request.Description,
            ReservedBy = request.ReservedBy,
            Status = "Active",
            CreatedAt = DateTime.UtcNow
        };

        _context.InventoryReservations.Add(reservation);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
