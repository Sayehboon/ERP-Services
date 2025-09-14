using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemSettings.Commands.UpdateSystemSettingByKey;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی تنظیم سیستم بر اساس کلید
/// </summary>
public sealed class UpdateSystemSettingByKeyCommandHandler : IRequestHandler<UpdateSystemSettingByKeyCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی تنظیم سیستم بر اساس کلید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateSystemSettingByKeyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی تنظیم سیستم بر اساس کلید
    /// </summary>
    public async Task<bool> Handle(UpdateSystemSettingByKeyCommand request, CancellationToken cancellationToken)
    {
        var systemSetting = await _context.SystemSettings.FirstOrDefaultAsync(ss => ss.Key == request.Key, cancellationToken);
        if (systemSetting == null)
        {
            throw new ArgumentException($"تنظیم با کلید {request.Key} یافت نشد");
        }

        // بررسی قابلیت ویرایش
        if (!systemSetting.IsEditable)
        {
            throw new InvalidOperationException($"تنظیم با کلید {request.Key} قابل ویرایش نیست");
        }

        // اعتبارسنجی نوع داده
        ValidateDataType(systemSetting.DataType, request.Value);

        systemSetting.Value = request.Value;
        systemSetting.UpdatedBy = request.UpdatedBy;
        systemSetting.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
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
