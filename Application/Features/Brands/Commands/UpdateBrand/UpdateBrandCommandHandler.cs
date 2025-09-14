using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Brands.Commands.UpdateBrand;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی برند
/// </summary>
public sealed class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی برند
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateBrandCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی برند
    /// </summary>
    public async Task<Guid> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
        if (brand == null)
        {
            throw new ArgumentException($"برند با شناسه {request.Id} یافت نشد");
        }

        var duplicate = await _context.Brands
            .AnyAsync(b => b.Name == request.Name && b.Id != request.Id, cancellationToken);
        if (duplicate)
        {
            throw new InvalidOperationException($"برندی با نام {request.Name} قبلاً وجود دارد");
        }

        brand.Name = request.Name;
        brand.Description = request.Description;
        brand.IsActive = request.IsActive;
        brand.SortOrder = request.SortOrder;
        brand.UpdatedBy = request.UpdatedBy;
        brand.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return brand.Id;
    }
}


