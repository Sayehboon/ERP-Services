using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities;

namespace Dinawin.Erp.Application.Features.Models.Commands.CreateModel;

/// <summary>
/// مدیریت‌کننده دستور ایجاد مدل
/// </summary>
public sealed class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد مدل
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateModelCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد مدل
    /// </summary>
    public async Task<Guid> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        // بررسی تکراری نبودن نام مدل
        var duplicate = await _context.Models
            .AnyAsync(m => m.Name == request.Name, cancellationToken);
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

        var model = new Model
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            BrandId = request.BrandId,
            IsActive = request.IsActive,
            SortOrder = request.SortOrder,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Models.Add(model);
        await _context.SaveChangesAsync(cancellationToken);
        return model.Id;
    }
}
