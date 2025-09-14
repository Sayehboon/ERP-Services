using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventories.InventoryMovements.Commands.DeleteInventoryMovement;

/// <summary>
/// مدیریت‌کننده دستور حذف حرکت موجودی
/// </summary>
public sealed class DeleteInventoryMovementCommandHandler : IRequestHandler<DeleteInventoryMovementCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف حرکت موجودی
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteInventoryMovementCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف حرکت موجودی
    /// </summary>
    public async Task<bool> Handle(DeleteInventoryMovementCommand request, CancellationToken cancellationToken)
    {
        var movement = await _context.InventoryMovements.FirstOrDefaultAsync(im => im.Id == request.Id, cancellationToken);
        if (movement == null)
        {
            throw new ArgumentException($"حرکت موجودی با شناسه {request.Id} یافت نشد");
        }

        // بررسی وابستگی‌ها قبل از حذف
        // در اینجا می‌توانید قوانین خاصی برای حذف تعریف کنید
        // مثلاً اگر حرکت بخشی از یک تراکنش مهم است، نباید حذف شود

        _context.InventoryMovements.Remove(movement);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
