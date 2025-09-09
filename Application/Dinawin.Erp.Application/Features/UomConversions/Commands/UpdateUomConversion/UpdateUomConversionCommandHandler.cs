using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.UomConversions.Commands.UpdateUomConversion;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی تبدیل واحد اندازه‌گیری
/// </summary>
public sealed class UpdateUomConversionCommandHandler : IRequestHandler<UpdateUomConversionCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی تبدیل واحد اندازه‌گیری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateUomConversionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی تبدیل واحد اندازه‌گیری
    /// </summary>
    public async Task<Guid> Handle(UpdateUomConversionCommand request, CancellationToken cancellationToken)
    {
        var uomConversion = await _context.UomConversions.FirstOrDefaultAsync(uc => uc.Id == request.Id, cancellationToken);
        if (uomConversion == null)
        {
            throw new ArgumentException($"تبدیل واحد اندازه‌گیری با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود واحد اندازه‌گیری مبدا
        var fromUomExists = await _context.UnitsOfMeasures
            .AnyAsync(u => u.Id == request.FromUomId, cancellationToken);
        if (!fromUomExists)
        {
            throw new ArgumentException($"واحد اندازه‌گیری مبدا با شناسه {request.FromUomId} یافت نشد");
        }

        // بررسی وجود واحد اندازه‌گیری مقصد
        var toUomExists = await _context.UnitsOfMeasures
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

        // بررسی یکتایی تبدیل (از یک واحد به واحد دیگر) - به جز خود تبدیل
        var conversionExists = await _context.UomConversions
            .AnyAsync(uc => uc.FromUomId == request.FromUomId && uc.ToUomId == request.ToUomId && uc.Id != request.Id, cancellationToken);
        if (conversionExists)
        {
            throw new ArgumentException($"تبدیل از واحد مبدا به واحد مقصد قبلاً وجود دارد");
        }

        uomConversion.FromUomId = request.FromUomId;
        uomConversion.ToUomId = request.ToUomId;
        uomConversion.ConversionFactor = request.ConversionFactor;
        uomConversion.Name = request.Name;
        uomConversion.Description = request.Description;
        uomConversion.IsActive = request.IsActive;
        uomConversion.UpdatedBy = request.UpdatedBy;
        uomConversion.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return uomConversion.Id;
    }
}
