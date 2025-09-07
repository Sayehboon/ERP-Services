using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities;

namespace Dinawin.Erp.Application.Features.Uoms.Commands.CreateUom;

/// <summary>
/// مدیریت‌کننده دستور ایجاد واحد اندازه‌گیری
/// </summary>
public sealed class CreateUomCommandHandler : IRequestHandler<CreateUomCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد واحد اندازه‌گیری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateUomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد واحد اندازه‌گیری
    /// </summary>
    public async Task<Guid> Handle(CreateUomCommand request, CancellationToken cancellationToken)
    {
        // بررسی یکتایی کد واحد اندازه‌گیری
        var codeExists = await _context.Uoms
            .AnyAsync(u => u.Code == request.Code, cancellationToken);
        if (codeExists)
        {
            throw new ArgumentException($"واحد اندازه‌گیری با کد {request.Code} قبلاً وجود دارد");
        }

        // بررسی یکتایی نام واحد اندازه‌گیری
        var nameExists = await _context.Uoms
            .AnyAsync(u => u.Name == request.Name, cancellationToken);
        if (nameExists)
        {
            throw new ArgumentException($"واحد اندازه‌گیری با نام {request.Name} قبلاً وجود دارد");
        }

        var uom = new Uom
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Code = request.Code,
            Symbol = request.Symbol,
            UomType = request.UomType,
            Description = request.Description,
            IsActive = request.IsActive,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Uoms.Add(uom);
        await _context.SaveChangesAsync(cancellationToken);
        return uom.Id;
    }
}
