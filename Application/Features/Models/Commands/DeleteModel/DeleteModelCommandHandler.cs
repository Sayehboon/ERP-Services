using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Models.Commands.DeleteModel;

/// <summary>
/// مدیریت‌کننده دستور حذف مدل
/// </summary>
public sealed class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف مدل
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteModelCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف مدل
    /// </summary>
    public async Task<bool> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.Models.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
        if (model == null)
        {
            throw new ArgumentException($"مدل با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود محصولات مرتبط
        var hasProducts = await _context.Products.AnyAsync(p => p.ModelId == request.Id, cancellationToken);
        if (hasProducts)
        {
            throw new InvalidOperationException("امکان حذف مدل وجود ندارد زیرا به کالاها مرتبط است");
        }

        _context.Models.Remove(model);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
