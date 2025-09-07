using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventory.Inventory.Commands.DeleteInventory;

/// <summary>
/// مدیریت‌کننده دستور حذف موجودی
/// </summary>
public sealed class DeleteInventoryCommandHandler : IRequestHandler<DeleteInventoryCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف موجودی
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteInventoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف موجودی
    /// </summary>
    public async Task<bool> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _context.Inventory.FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);
        if (inventory == null)
        {
            throw new ArgumentException($"موجودی با شناسه {request.Id} یافت نشد");
        }

        // بررسی وابستگی‌ها قبل از حذف
        var hasMovements = await _context.InventoryMovements
            .AnyAsync(im => im.InventoryId == request.Id, cancellationToken);
        
        if (hasMovements)
        {
            throw new InvalidOperationException("امکان حذف موجودی به دلیل وجود حرکات وابسته وجود ندارد");
        }

        _context.Inventory.Remove(inventory);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
