using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Trims.Commands.DeleteTrim;

/// <summary>
/// مدیریت‌کننده دستور حذف تریم
/// </summary>
public sealed class DeleteTrimCommandHandler : IRequestHandler<DeleteTrimCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف تریم
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteTrimCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف تریم
    /// </summary>
    public async Task<bool> Handle(DeleteTrimCommand request, CancellationToken cancellationToken)
    {
        var trim = await _context.Trims.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        if (trim == null)
        {
            throw new ArgumentException($"تریم با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود محصولات مرتبط
        var hasProducts = await _context.Products.AnyAsync(p => p.TrimId == request.Id, cancellationToken);
        if (hasProducts)
        {
            throw new InvalidOperationException("امکان حذف تریم وجود ندارد زیرا به کالاها مرتبط است");
        }

        _context.Trims.Remove(trim);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
