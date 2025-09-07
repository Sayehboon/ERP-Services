using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Models.Commands.UpdateModel;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی مدل
/// </summary>
public sealed class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی مدل
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateModelCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی مدل
    /// </summary>
    public async Task<Guid> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.Models.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
        if (model == null)
        {
            throw new ArgumentException($"مدل با شناسه {request.Id} یافت نشد");
        }

        // بررسی تکراری نبودن نام مدل
        var duplicate = await _context.Models
            .AnyAsync(m => m.Name == request.Name && m.Id != request.Id, cancellationToken);
        if (duplicate)
        {
            throw new InvalidOperationException($"مدلی با نام {request.Name} قبلاً وجود دارد");
        }

        // بررسی وجود برند
        if (request.BrandId.HasValue)
        {
            var brandExists = await _context.Brands
                .AnyAsync(b => b.Id == request.BrandId.Value, cancellationToken);
            if (!brandExists)
            {
                throw new ArgumentException($"برند با شناسه {request.BrandId} یافت نشد");
            }
        }

        model.Name = request.Name;
        model.Description = request.Description;
        model.BrandId = request.BrandId;
        model.IsActive = request.IsActive;
        model.SortOrder = request.SortOrder;
        model.UpdatedBy = request.UpdatedBy;
        model.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return model.Id;
    }
}
