using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Categories.Commands.DeleteCategory;

/// <summary>
/// مدیریت‌کننده دستور حذف دسته‌بندی
/// </summary>
public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف دسته‌بندی
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف دسته‌بندی
    /// </summary>
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (category == null)
        {
            throw new ArgumentException($"دسته‌بندی با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود محصولات مرتبط
        var hasProducts = await _context.Products.AnyAsync(p => p.CategoryId == request.Id, cancellationToken);
        if (hasProducts)
        {
            throw new InvalidOperationException("امکان حذف دسته‌بندی وجود ندارد زیرا به کالاها مرتبط است");
        }

        // بررسی وجود زیردسته‌ها
        var hasSubcategories = await _context.Categories.AnyAsync(c => c.ParentCategoryId == request.Id, cancellationToken);
        if (hasSubcategories)
        {
            throw new InvalidOperationException("امکان حذف دسته‌بندی وجود ندارد زیرا دارای زیردسته است");
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
