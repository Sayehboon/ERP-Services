using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemSettings.Commands.ResetSystemSettings;

/// <summary>
/// مدیریت‌کننده دستور بازنشانی تنظیمات سیستم
/// </summary>
public sealed class ResetSystemSettingsCommandHandler : IRequestHandler<ResetSystemSettingsCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور بازنشانی تنظیمات سیستم
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public ResetSystemSettingsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور بازنشانی تنظیمات سیستم
    /// </summary>
    public async Task<bool> Handle(ResetSystemSettingsCommand request, CancellationToken cancellationToken)
    {
        var query = _context.SystemSettings.AsQueryable();

        // فیلتر بر اساس دسته‌بندی اگر مشخص شده باشد
        if (!string.IsNullOrWhiteSpace(request.Category))
        {
            query = query.Where(ss => ss.Category == request.Category);
        }

        var settings = await query.ToListAsync(cancellationToken);
        var resetCount = 0;

        foreach (var setting in settings)
        {
            // فقط تنظیمات قابل ویرایش را بازنشانی کن
            if (setting.IsEditable && !string.IsNullOrWhiteSpace(setting.DefaultValue))
            {
                setting.Value = setting.DefaultValue;
                setting.UpdatedBy = request.ResetBy;
                setting.UpdatedAt = DateTime.UtcNow;
                resetCount++;
            }
        }

        if (resetCount > 0)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        return true;
    }
}
