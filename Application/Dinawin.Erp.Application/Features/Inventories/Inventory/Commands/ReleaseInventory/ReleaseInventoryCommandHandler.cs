using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Inventories;

namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Commands.ReleaseInventory;

/// <summary>
/// پردازش‌کننده دستور آزادسازی موجودی رزرو شده
/// </summary>
public sealed class ReleaseInventoryCommandHandler : IRequestHandler<ReleaseInventoryCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازش‌کننده دستور آزادسازی موجودی رزرو شده
    /// </summary>
    public ReleaseInventoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور آزادسازی موجودی رزرو شده
    /// </summary>
    public async Task<bool> Handle(ReleaseInventoryCommand request, CancellationToken cancellationToken)
    {
        List<InventoryReservation> reservations;

        if (request.ReservationId.HasValue)
        {
            // آزادسازی رزرو خاص
            var reservation = await _context.InventoryReservations
                .FirstOrDefaultAsync(r => r.Id == request.ReservationId.Value && r.Status == "Active", cancellationToken);

            if (reservation == null)
            {
                throw new ArgumentException("رزرو یافت نشد یا قبلاً آزاد شده است");
            }

            reservations = new List<InventoryReservation> { reservation };
        }
        else
        {
            // آزادسازی رزروها بر اساس معیارهای دیگر
            var query = _context.InventoryReservations
                .Where(r => r.Status == "Active");

            if (request.ProductId.HasValue)
                query = query.Where(r => r.ProductId == request.ProductId.Value);

            if (request.WarehouseId.HasValue)
                query = query.Where(r => r.WarehouseId == request.WarehouseId.Value);

            if (request.BinId.HasValue)
                query = query.Where(r => r.BinId == request.BinId.Value);

            if (!string.IsNullOrEmpty(request.ReferenceNumber))
                query = query.Where(r => r.ReferenceNumber == request.ReferenceNumber);

            if (!string.IsNullOrEmpty(request.ReferenceType))
                query = query.Where(r => r.ReferenceType == request.ReferenceType);

            if (request.ReferenceId.HasValue)
                query = query.Where(r => r.ReferenceId == request.ReferenceId.Value);

            reservations = await query.ToListAsync(cancellationToken);

            if (!reservations.Any())
            {
                throw new ArgumentException("رزروی با معیارهای مشخص شده یافت نشد");
            }
        }

        foreach (var reservation in reservations)
        {
            // دریافت موجودی
            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(i => i.ProductId == reservation.ProductId && 
                                        i.WarehouseId == reservation.WarehouseId && 
                                        i.BinId == reservation.BinId, cancellationToken);

            if (inventory == null)
            {
                throw new InvalidOperationException("موجودی یافت نشد");
            }

            // محاسبه مقدار آزادسازی
            var releaseQuantity = request.Quantity ?? reservation.Quantity;

            if (releaseQuantity > reservation.Quantity)
            {
                throw new ArgumentException("مقدار آزادسازی نمی‌تواند بیشتر از مقدار رزرو باشد");
            }

            // آزادسازی موجودی
            inventory.QuantityReserved -= releaseQuantity;
            inventory.QuantityAvailable = inventory.QuantityOnHand - inventory.QuantityReserved;
            inventory.UpdatedAt = DateTime.UtcNow;

            // به‌روزرسانی وضعیت رزرو
            if (releaseQuantity == reservation.Quantity)
            {
                // آزادسازی کامل
                reservation.Status = "Released";
                reservation.ReleasedAt = DateTime.UtcNow;
                reservation.ReleasedBy = request.ReleasedBy;
            }
            else
            {
                // آزادسازی جزئی
                reservation.Quantity -= releaseQuantity;
                reservation.UpdatedAt = DateTime.UtcNow;
            }
        }

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
