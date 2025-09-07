using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities;

namespace Dinawin.Erp.Application.Features.Units.Commands.CreateUnit;

/// <summary>
/// مدیریت‌کننده دستور ایجاد واحد اندازه‌گیری
/// </summary>
public sealed class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد واحد اندازه‌گیری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateUnitCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد واحد اندازه‌گیری
    /// </summary>
    public async Task<Guid> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
    {
        // بررسی تکراری نبودن نام واحد
        var duplicateName = await _context.Units
            .AnyAsync(u => u.Name == request.Name, cancellationToken);
        if (duplicateName)
        {
            throw new InvalidOperationException($"واحدی با نام {request.Name} قبلاً وجود دارد");
        }

        // بررسی تکراری نبودن کد واحد
        var duplicateCode = await _context.Units
            .AnyAsync(u => u.Code == request.Code, cancellationToken);
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
        }

        var unit = new Unit
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Code = request.Code,
            Symbol = request.Symbol,
            Description = request.Description,
            UnitType = request.UnitType,
            ConversionFactor = request.ConversionFactor,
            BaseUnitId = request.BaseUnitId,
            IsActive = request.IsActive,
            SortOrder = request.SortOrder,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Units.Add(unit);
        await _context.SaveChangesAsync(cancellationToken);
        return unit.Id;
    }
}
