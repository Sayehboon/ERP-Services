using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventory.Inventory.Commands.UpdateInventory;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی موجودی
/// </summary>
public sealed class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی موجودی
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateInventoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی موجودی
    /// </summary>
    public async Task<Guid> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _context.Inventory.FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);
        if (inventory == null)
        {
            throw new ArgumentException($"موجودی با شناسه {request.Id} یافت نشد");
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

        // اعتبارسنجی مقادیر
        if (request.ReservedQuantity > request.Quantity)
        {
            throw new ArgumentException("مقدار رزرو شده نمی‌تواند بیشتر از مقدار موجودی باشد");
        }

        if (request.MinQuantity > request.MaxQuantity && request.MaxQuantity > 0)
        {
            throw new ArgumentException("حداقل موجودی نمی‌تواند بیشتر از حداکثر موجودی باشد");
        }

        inventory.ProductId = request.ProductId;
        inventory.WarehouseId = request.WarehouseId;
        inventory.BinId = request.BinId;
        inventory.Quantity = request.Quantity;
        inventory.ReservedQuantity = request.ReservedQuantity;
        inventory.MinQuantity = request.MinQuantity;
        inventory.MaxQuantity = request.MaxQuantity;
        inventory.UnitPrice = request.UnitPrice;
        inventory.ExpiryDate = request.ExpiryDate;
        inventory.SerialNumber = request.SerialNumber;
        inventory.Description = request.Description;
        inventory.UpdatedBy = request.UpdatedBy;
        inventory.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return inventory.Id;
    }
}
