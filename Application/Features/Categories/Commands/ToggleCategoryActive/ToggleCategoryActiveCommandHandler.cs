using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Categories.Commands.ToggleCategoryActive;

/// <summary>
/// پردازش‌کننده دستور تغییر وضعیت فعال/غیرفعال دسته‌بندی
/// </summary>
public sealed class ToggleCategoryActiveCommandHandler : IRequestHandler<ToggleCategoryActiveCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازش‌کننده دستور تغییر وضعیت فعال/غیرفعال دسته‌بندی
    /// </summary>
    public ToggleCategoryActiveCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور تغییر وضعیت فعال/غیرفعال دسته‌بندی
    /// </summary>
    public async Task<bool> Handle(ToggleCategoryActiveCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (category == null)
        {
            throw new ArgumentException($"دسته‌بندی با شناسه {request.Id} یافت نشد");
        }

        // تغییر وضعیت فعال/غیرفعال
        category.IsActive = !category.IsActive;
        category.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return category.IsActive;
    }
}
