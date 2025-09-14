using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemSettings.Commands.UpdateSystemSetting;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی تنظیم سیستم
/// </summary>
public sealed class UpdateSystemSettingCommandHandler : IRequestHandler<UpdateSystemSettingCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی تنظیم سیستم
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateSystemSettingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی تنظیم سیستم
    /// </summary>
    public async Task<Guid> Handle(UpdateSystemSettingCommand request, CancellationToken cancellationToken)
    {
        var systemSetting = await _context.SystemSettings.FirstOrDefaultAsync(ss => ss.Id == request.Id, cancellationToken);
        if (systemSetting == null)
        {
            throw new ArgumentException($"تنظیم سیستم با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتایی کلید تنظیم (به جز خود تنظیم)
        var keyExists = await _context.SystemSettings
            .AnyAsync(ss => ss.Key == request.Key && ss.Id != request.Id, cancellationToken);
        if (keyExists)
        {
            throw new ArgumentException($"تنظیم با کلید {request.Key} قبلاً وجود دارد");
        }

        // اعتبارسنجی نوع داده
        ValidateDataType(request.DataType, request.Value);

        systemSetting.Key = request.Key;
        systemSetting.Value = request.Value;
        systemSetting.Description = request.Description ?? string.Empty;
        systemSetting.Category = request.Category;
        systemSetting.DataType = request.DataType;
        systemSetting.IsEditable = request.IsEditable;
        systemSetting.IsActive = request.IsActive;
        systemSetting.DefaultValue = request.DefaultValue ?? string.Empty;
        systemSetting.UpdatedBy = request.UpdatedBy;
        systemSetting.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return systemSetting.Id;
    }

    /// <summary>
    /// اعتبارسنجی نوع داده
    /// </summary>
    private static void ValidateDataType(string dataType, string value)
    {
        switch (dataType.ToLower())
        {
            case "integer":
                if (!int.TryParse(value, out _))
                    throw new ArgumentException($"مقدار '{value}' برای نوع داده Integer معتبر نیست");
                break;
            case "decimal":
                if (!decimal.TryParse(value, out _))
                    throw new ArgumentException($"مقدار '{value}' برای نوع داده Decimal معتبر نیست");
                break;
            case "boolean":
                if (!bool.TryParse(value, out _))
                    throw new ArgumentException($"مقدار '{value}' برای نوع داده Boolean معتبر نیست");
                break;
            case "datetime":
                if (!DateTime.TryParse(value, out _))
                    throw new ArgumentException($"مقدار '{value}' برای نوع داده DateTime معتبر نیست");
                break;
            case "string":
                // String همیشه معتبر است
                break;
            default:
                throw new ArgumentException($"نوع داده '{dataType}' پشتیبانی نمی‌شود");
        }
    }
}
