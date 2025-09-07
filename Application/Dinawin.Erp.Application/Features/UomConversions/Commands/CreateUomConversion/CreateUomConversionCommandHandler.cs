using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities;

namespace Dinawin.Erp.Application.Features.UomConversions.Commands.CreateUomConversion;

/// <summary>
/// مدیریت‌کننده دستور ایجاد تبدیل واحد اندازه‌گیری
/// </summary>
public sealed class CreateUomConversionCommandHandler : IRequestHandler<CreateUomConversionCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد تبدیل واحد اندازه‌گیری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateUomConversionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد تبدیل واحد اندازه‌گیری
    /// </summary>
    public async Task<Guid> Handle(CreateUomConversionCommand request, CancellationToken cancellationToken)
    {
        // بررسی وجود واحد اندازه‌گیری مبدا
        var fromUomExists = await _context.Uoms
            .AnyAsync(u => u.Id == request.FromUomId, cancellationToken);
        if (!fromUomExists)
        {
            throw new ArgumentException($"واحد اندازه‌گیری مبدا با شناسه {request.FromUomId} یافت نشد");
        }

        // بررسی وجود واحد اندازه‌گیری مقصد
        var toUomExists = await _context.Uoms
            .AnyAsync(u => u.Id == request.ToUomId, cancellationToken);
        if (!toUomExists)
        {
            throw new ArgumentException($"واحد اندازه‌گیری مقصد با شناسه {request.ToUomId} یافت نشد");
        }

        // بررسی عدم یکسان بودن واحدهای مبدا و مقصد
        if (request.FromUomId == request.ToUomId)
        {
            throw new ArgumentException("واحد اندازه‌گیری مبدا و مقصد نمی‌توانند یکسان باشند");
        }

        // بررسی یکتایی تبدیل (از یک واحد به واحد دیگر)
        var conversionExists = await _context.UomConversions
            .AnyAsync(uc => uc.FromUomId == request.FromUomId && uc.ToUomId == request.ToUomId, cancellationToken);
        if (conversionExists)
        {
            throw new ArgumentException($"تبدیل از واحد مبدا به واحد مقصد قبلاً وجود دارد");
        }

        var uomConversion = new UomConversion
        {
            Id = Guid.NewGuid(),
            FromUomId = request.FromUomId,
            ToUomId = request.ToUomId,
            ConversionFactor = request.ConversionFactor,
            Name = request.Name,
            Description = request.Description,
            IsActive = request.IsActive,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.UomConversions.Add(uomConversion);
        await _context.SaveChangesAsync(cancellationToken);
        return uomConversion.Id;
    }
}
