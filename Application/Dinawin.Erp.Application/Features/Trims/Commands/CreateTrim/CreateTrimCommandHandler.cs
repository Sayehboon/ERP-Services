using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities;

namespace Dinawin.Erp.Application.Features.Trims.Commands.CreateTrim;

/// <summary>
/// مدیریت‌کننده دستور ایجاد تریم
/// </summary>
public sealed class CreateTrimCommandHandler : IRequestHandler<CreateTrimCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد تریم
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateTrimCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد تریم
    /// </summary>
    public async Task<Guid> Handle(CreateTrimCommand request, CancellationToken cancellationToken)
    {
        // بررسی تکراری نبودن نام تریم
        var duplicate = await _context.Trims
            .AnyAsync(t => t.Name == request.Name, cancellationToken);
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

        var trim = new Trim
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            ModelId = request.ModelId,
            IsActive = request.IsActive,
            SortOrder = request.SortOrder,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Trims.Add(trim);
        await _context.SaveChangesAsync(cancellationToken);
        return trim.Id;
    }
}
