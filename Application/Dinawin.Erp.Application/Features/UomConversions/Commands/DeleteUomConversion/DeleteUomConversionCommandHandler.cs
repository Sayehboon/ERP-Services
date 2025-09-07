using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.UomConversions.Commands.DeleteUomConversion;

/// <summary>
/// مدیریت‌کننده دستور حذف تبدیل واحد اندازه‌گیری
/// </summary>
public sealed class DeleteUomConversionCommandHandler : IRequestHandler<DeleteUomConversionCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف تبدیل واحد اندازه‌گیری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteUomConversionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف تبدیل واحد اندازه‌گیری
    /// </summary>
    public async Task<bool> Handle(DeleteUomConversionCommand request, CancellationToken cancellationToken)
    {
        var uomConversion = await _context.UomConversions.FirstOrDefaultAsync(uc => uc.Id == request.Id, cancellationToken);
        if (uomConversion == null)
        {
            throw new ArgumentException($"تبدیل واحد اندازه‌گیری با شناسه {request.Id} یافت نشد");
        }

        // در حال حاضر هیچ وابستگی خاصی برای تبدیلات UOM وجود ندارد
        // اما در آینده ممکن است در محاسبات موجودی یا سایر عملیات استفاده شود

        _context.UomConversions.Remove(uomConversion);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
