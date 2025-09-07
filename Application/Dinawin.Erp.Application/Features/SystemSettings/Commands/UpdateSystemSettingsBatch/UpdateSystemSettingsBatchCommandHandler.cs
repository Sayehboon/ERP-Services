using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemSettings.Commands.UpdateSystemSettingsBatch;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی دسته‌ای تنظیمات سیستم
/// </summary>
public sealed class UpdateSystemSettingsBatchCommandHandler : IRequestHandler<UpdateSystemSettingsBatchCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی دسته‌ای تنظیمات سیستم
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateSystemSettingsBatchCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی دسته‌ای تنظیمات سیستم
    /// </summary>
    public async Task<bool> Handle(UpdateSystemSettingsBatchCommand request, CancellationToken cancellationToken)
    {
        var updatedCount = 0;
        var errors = new List<string>();

        foreach (var settingItem in request.Settings)
        {
            try
            {
                var systemSetting = await _context.SystemSettings
                    .FirstOrDefaultAsync(ss => ss.Key == settingItem.Key, cancellationToken);

                if (systemSetting == null)
                {
                    errors.Add($"تنظیم با کلید {settingItem.Key} یافت نشد");
                    continue;
                }

                // بررسی قابلیت ویرایش
                if (!systemSetting.IsEditable)
                {
                    errors.Add($"تنظیم با کلید {settingItem.Key} قابل ویرایش نیست");
                    continue;
                }

                // اعتبارسنجی نوع داده
                try
                {
                    ValidateDataType(systemSetting.DataType, settingItem.Value);
                }
                catch (ArgumentException ex)
                {
                    errors.Add($"خطا در تنظیم {settingItem.Key}: {ex.Message}");
                    continue;
                }

                systemSetting.Value = settingItem.Value;
                systemSetting.UpdatedBy = request.UpdatedBy;
                systemSetting.UpdatedAt = DateTime.UtcNow;
                updatedCount++;
            }
            catch (Exception ex)
            {
                errors.Add($"خطا در به‌روزرسانی تنظیم {settingItem.Key}: {ex.Message}");
            }
        }

        if (errors.Any())
        {
            throw new InvalidOperationException($"خطا در به‌روزرسانی برخی تنظیمات:\n{string.Join("\n", errors)}");
        }

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
