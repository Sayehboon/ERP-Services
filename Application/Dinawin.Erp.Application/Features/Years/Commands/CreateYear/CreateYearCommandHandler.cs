using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities;

namespace Dinawin.Erp.Application.Features.Years.Commands.CreateYear;

/// <summary>
/// مدیریت‌کننده دستور ایجاد سال
/// </summary>
public sealed class CreateYearCommandHandler : IRequestHandler<CreateYearCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد سال
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateYearCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد سال
    /// </summary>
    public async Task<Guid> Handle(CreateYearCommand request, CancellationToken cancellationToken)
    {
        // بررسی تکراری نبودن سال
        var duplicate = await _context.Years
            .AnyAsync(y => y.Year == request.Year, cancellationToken);
        if (duplicate)
        {
            throw new InvalidOperationException($"سالی با شماره {request.Year} قبلاً وجود دارد");
        }

        var year = new Year
        {
            Id = Guid.NewGuid(),
            Year = request.Year,
            Description = request.Description,
            IsActive = request.IsActive,
            SortOrder = request.SortOrder,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Years.Add(year);
        await _context.SaveChangesAsync(cancellationToken);
        return year.Id;
    }
}
