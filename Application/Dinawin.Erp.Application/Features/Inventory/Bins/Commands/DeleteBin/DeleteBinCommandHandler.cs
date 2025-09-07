using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventory.Bins.Commands.DeleteBin;

/// <summary>
/// مدیریت‌کننده دستور حذف مکان
/// </summary>
public sealed class DeleteBinCommandHandler : IRequestHandler<DeleteBinCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف مکان
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteBinCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف مکان
    /// </summary>
    public async Task<bool> Handle(DeleteBinCommand request, CancellationToken cancellationToken)
    {
        var bin = await _context.Bins.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
        if (bin == null)
        {
            throw new ArgumentException($"مکان با شناسه {request.Id} یافت نشد");
        }

        // بررسی وابستگی‌ها قبل از حذف
        var hasInventory = await _context.Inventory
            .AnyAsync(i => i.BinId == request.Id, cancellationToken);
        
        var hasMovements = await _context.InventoryMovements
            .AnyAsync(im => im.BinId == request.Id, cancellationToken);
        
        if (hasInventory || hasMovements)
        {
            throw new InvalidOperationException("امکان حذف مکان به دلیل وجود موجودی یا حرکات وابسته وجود ندارد");
        }

        _context.Bins.Remove(bin);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
