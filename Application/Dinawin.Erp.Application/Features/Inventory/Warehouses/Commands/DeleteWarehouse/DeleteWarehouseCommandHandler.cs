using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventory.Warehouses.Commands.DeleteWarehouse;

/// <summary>
/// مدیریت‌کننده دستور حذف انبار
/// </summary>
public sealed class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف انبار
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteWarehouseCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف انبار
    /// </summary>
    public async Task<bool> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = await _context.Warehouses.FirstOrDefaultAsync(w => w.Id == request.Id, cancellationToken);
        if (warehouse == null)
        {
            throw new ArgumentException($"انبار با شناسه {request.Id} یافت نشد");
        }

        // بررسی وابستگی‌ها قبل از حذف
        var hasInventory = await _context.Inventory
            .AnyAsync(i => i.WarehouseId == request.Id, cancellationToken);
        
        var hasBins = await _context.Bins
            .AnyAsync(b => b.WarehouseId == request.Id, cancellationToken);
        
        var hasMovements = await _context.InventoryMovements
            .AnyAsync(im => im.WarehouseId == request.Id, cancellationToken);
        
        if (hasInventory || hasBins || hasMovements)
        {
            throw new InvalidOperationException("امکان حذف انبار به دلیل وجود موجودی، مکان‌ها یا حرکات وابسته وجود ندارد");
        }

        _context.Warehouses.Remove(warehouse);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
