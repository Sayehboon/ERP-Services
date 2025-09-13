using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Trims.Commands.UpdateTrim;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی تریم
/// </summary>
public sealed class UpdateTrimCommandHandler : IRequestHandler<UpdateTrimCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی تریم
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateTrimCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی تریم
    /// </summary>
    public async Task<Guid> Handle(UpdateTrimCommand request, CancellationToken cancellationToken)
    {
        var trim = await _context.Trims.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        if (trim == null)
        {
            throw new ArgumentException($"تریم با شناسه {request.Id} یافت نشد");
        }

        // بررسی تکراری نبودن نام تریم
        var duplicate = await _context.Trims
            .AnyAsync(t => t.Name == request.Name && t.Id != request.Id, cancellationToken);
        if (duplicate)
        {
            throw new InvalidOperationException($"تریمی با نام {request.Name} قبلاً وجود دارد");
        }

        // بررسی وجود مدل
        if (request.ModelId.HasValue)
        {
            var modelExists = await _context.Models
                .AnyAsync(m => m.Id == request.ModelId.Value, cancellationToken);
            if (!modelExists)
            {
                throw new ArgumentException($"مدل با شناسه {request.ModelId} یافت نشد");
            }
        }

        trim.Name = request.Name;
        trim.Description = request.Description;
        trim.ModelId = request.ModelId ?? Guid.Empty;
        trim.IsActive = request.IsActive;
        trim.SortOrder = request.SortOrder;
        trim.UpdatedBy = request.UpdatedBy;
        trim.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return trim.Id;
    }
}
