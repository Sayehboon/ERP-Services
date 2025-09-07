using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Brands.Commands.DeleteBrand;

/// <summary>
/// مدیریت‌کننده دستور حذف برند
/// </summary>
public sealed class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف برند
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteBrandCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف برند
    /// </summary>
    public async Task<bool> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
        if (brand == null)
        {
            throw new ArgumentException($"برند با شناسه {request.Id} یافت نشد");
        }

        var hasProducts = await _context.Products.AnyAsync(p => p.BrandId == request.Id, cancellationToken);
        if (hasProducts)
        {
            throw new InvalidOperationException("امکان حذف برند وجود ندارد زیرا به کالاها مرتبط است");
        }

        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}


