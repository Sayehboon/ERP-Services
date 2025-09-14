using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Categories.Commands.UpdateCategory;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی دسته‌بندی
/// </summary>
public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی دسته‌بندی
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی دسته‌بندی
    /// </summary>
    public async Task<Guid> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (category == null)
        {
            throw new ArgumentException($"دسته‌بندی با شناسه {request.Id} یافت نشد");
        }

        // بررسی تکراری نبودن نام دسته‌بندی
        var duplicate = await _context.Categories
            .AnyAsync(c => c.Name == request.Name && c.Id != request.Id, cancellationToken);
        if (duplicate)
        {
            throw new InvalidOperationException($"دسته‌بندی با نام {request.Name} قبلاً وجود دارد");
        }

        // بررسی وجود دسته‌بندی والد
        if (request.ParentCategoryId.HasValue)
        {
            var parentExists = await _context.Categories
                .AnyAsync(c => c.Id == request.ParentCategoryId.Value, cancellationToken);
            if (!parentExists)
            {
                throw new ArgumentException($"دسته‌بندی والد با شناسه {request.ParentCategoryId} یافت نشد");
            }

            // بررسی عدم ایجاد حلقه در سلسله مراتب
            if (request.ParentCategoryId.Value == request.Id)
            {
                throw new InvalidOperationException("دسته‌بندی نمی‌تواند والد خود باشد");
            }
        }

        category.Name = request.Name;
        category.Description = request.Description;
        category.ParentCategoryId = request.ParentCategoryId;
        category.IsActive = request.IsActive;
        category.SortOrder = request.SortOrder;
        category.UpdatedBy = request.UpdatedBy;
        category.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}
