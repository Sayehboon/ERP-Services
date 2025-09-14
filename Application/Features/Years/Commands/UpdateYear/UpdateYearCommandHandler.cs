using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Years.Commands.UpdateYear;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی سال
/// </summary>
public sealed class UpdateYearCommandHandler : IRequestHandler<UpdateYearCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی سال
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateYearCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی سال
    /// </summary>
    public async Task<Guid> Handle(UpdateYearCommand request, CancellationToken cancellationToken)
    {
        var year = await _context.Years.FirstOrDefaultAsync(y => y.Id == request.Id, cancellationToken);
        if (year == null)
        {
            throw new ArgumentException($"سال با شناسه {request.Id} یافت نشد");
        }

        // بررسی تکراری نبودن سال
        var duplicate = await _context.Years
            .AnyAsync(y => y.YearValue == request.Year && y.Id != request.Id, cancellationToken);
        if (duplicate)
        {
            throw new InvalidOperationException($"سالی با شماره {request.Year} قبلاً وجود دارد");
        }

        year.YearValue = request.Year;
        year.Description = request.Description;
        year.IsActive = request.IsActive;
        year.UpdatedBy = request.UpdatedBy;
        year.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return year.Id;
    }
}
