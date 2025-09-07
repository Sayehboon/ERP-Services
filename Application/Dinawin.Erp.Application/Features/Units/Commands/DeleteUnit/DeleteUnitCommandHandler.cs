using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Units.Commands.DeleteUnit;

/// <summary>
/// مدیریت‌کننده دستور حذف واحد اندازه‌گیری
/// </summary>
public sealed class DeleteUnitCommandHandler : IRequestHandler<DeleteUnitCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف واحد اندازه‌گیری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteUnitCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف واحد اندازه‌گیری
    /// </summary>
    public async Task<bool> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
    {
        var unit = await _context.Units.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        if (unit == null)
        {
            throw new ArgumentException($"واحد اندازه‌گیری با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود محصولات مرتبط
        var hasProducts = await _context.Products.AnyAsync(p => p.UnitId == request.Id, cancellationToken);
        if (hasProducts)
        {
            throw new InvalidOperationException("امکان حذف واحد اندازه‌گیری وجود ندارد زیرا به کالاها مرتبط است");
        }

        // بررسی وجود واحدهای وابسته
        var hasDependentUnits = await _context.Units.AnyAsync(u => u.BaseUnitId == request.Id, cancellationToken);
        if (hasDependentUnits)
        {
            throw new InvalidOperationException("امکان حذف واحد اندازه‌گیری وجود ندارد زیرا واحدهای دیگری به آن وابسته هستند");
        }

        _context.Units.Remove(unit);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
