using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Uoms.Commands.UpdateUom;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی واحد اندازه‌گیری
/// </summary>
public sealed class UpdateUomCommandHandler : IRequestHandler<UpdateUomCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی واحد اندازه‌گیری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateUomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی واحد اندازه‌گیری
    /// </summary>
    public async Task<Guid> Handle(UpdateUomCommand request, CancellationToken cancellationToken)
    {
        var uom = await _context.Uoms.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        if (uom == null)
        {
            throw new ArgumentException($"واحد اندازه‌گیری با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتایی کد واحد اندازه‌گیری (به جز خود واحد)
        var codeExists = await _context.Uoms
            .AnyAsync(u => u.Code == request.Code && u.Id != request.Id, cancellationToken);
        if (codeExists)
        {
            throw new ArgumentException($"واحد اندازه‌گیری با کد {request.Code} قبلاً وجود دارد");
        }

        // بررسی یکتایی نام واحد اندازه‌گیری (به جز خود واحد)
        var nameExists = await _context.Uoms
            .AnyAsync(u => u.Name == request.Name && u.Id != request.Id, cancellationToken);
        if (nameExists)
        {
            throw new ArgumentException($"واحد اندازه‌گیری با نام {request.Name} قبلاً وجود دارد");
        }

        uom.Name = request.Name;
        uom.Code = request.Code;
        uom.Symbol = request.Symbol;
        uom.UomType = request.UomType;
        uom.Description = request.Description;
        uom.IsActive = request.IsActive;
        uom.UpdatedBy = request.UpdatedBy;
        uom.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return uom.Id;
    }
}
