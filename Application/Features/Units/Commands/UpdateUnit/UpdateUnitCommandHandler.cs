using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Units.Commands.UpdateUnit;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی واحد اندازه‌گیری
/// </summary>
public sealed class UpdateUnitCommandHandler : IRequestHandler<UpdateUnitCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی واحد اندازه‌گیری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateUnitCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی واحد اندازه‌گیری
    /// </summary>
    public async Task<Guid> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
    {
        var unit = await _context.Units.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        if (unit == null)
        {
            throw new ArgumentException($"واحد اندازه‌گیری با شناسه {request.Id} یافت نشد");
        }

        // بررسی تکراری نبودن نام واحد
        var duplicateName = await _context.Units
            .AnyAsync(u => u.Name == request.Name && u.Id != request.Id, cancellationToken);
        if (duplicateName)
        {
            throw new InvalidOperationException($"واحدی با نام {request.Name} قبلاً وجود دارد");
        }

        // بررسی تکراری نبودن کد واحد
        var duplicateCode = await _context.Units
            .AnyAsync(u => u.Code == request.Code && u.Id != request.Id, cancellationToken);
        if (duplicateCode)
        {
            throw new InvalidOperationException($"واحدی با کد {request.Code} قبلاً وجود دارد");
        }

        // بررسی وجود واحد پایه
        if (request.BaseUnitId.HasValue)
        {
            var baseUnitExists = await _context.Units
                .AnyAsync(u => u.Id == request.BaseUnitId.Value, cancellationToken);
            if (!baseUnitExists)
            {
                throw new ArgumentException($"واحد پایه با شناسه {request.BaseUnitId} یافت نشد");
            }

            // بررسی عدم ایجاد حلقه در سلسله مراتب
            if (request.BaseUnitId.Value == request.Id)
            {
                throw new InvalidOperationException("واحد نمی‌تواند پایه خود باشد");
            }
        }

        unit.Name = request.Name;
        unit.Code = request.Code;
        unit.Symbol = request.Symbol;
        unit.Description = request.Description;
        unit.UnitType = request.UnitType;
        unit.ConversionFactor = request.ConversionFactor;
        unit.BaseUnitId = request.BaseUnitId;
        unit.IsActive = request.IsActive;
        unit.SortOrder = request.SortOrder;
        unit.UpdatedBy = request.UpdatedBy;
        unit.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return unit.Id;
    }
}
