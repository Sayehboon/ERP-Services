using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Uoms.Commands.DeleteUom;

/// <summary>
/// مدیریت‌کننده دستور حذف واحد اندازه‌گیری
/// </summary>
public sealed class DeleteUomCommandHandler : IRequestHandler<DeleteUomCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف واحد اندازه‌گیری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteUomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف واحد اندازه‌گیری
    /// </summary>
    public async Task<bool> Handle(DeleteUomCommand request, CancellationToken cancellationToken)
    {
        var uom = await _context.Uoms.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        if (uom == null)
        {
            throw new ArgumentException($"واحد اندازه‌گیری با شناسه {request.Id} یافت نشد");
        }

        // بررسی استفاده در محصولات
        var hasProducts = await _context.Products.AnyAsync(p => p.UomId == request.Id, cancellationToken);
        if (hasProducts)
        {
            throw new InvalidOperationException("امکان حذف واحد اندازه‌گیری وجود ندارد زیرا در محصولات استفاده شده است");
        }

        // بررسی استفاده در تبدیلات UOM
        var hasUomConversions = await _context.UomConversions.AnyAsync(uc => uc.FromUomId == request.Id || uc.ToUomId == request.Id, cancellationToken);
        if (hasUomConversions)
        {
            throw new InvalidOperationException("امکان حذف واحد اندازه‌گیری وجود ندارد زیرا در تبدیلات UOM استفاده شده است");
        }

        _context.Uoms.Remove(uom);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
