using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Systems;

namespace Dinawin.Erp.Application.Features.SystemSettings.Commands.CreateSystemSetting;

/// <summary>
/// مدیریت‌کننده دستور ایجاد تنظیم سیستم
/// </summary>
public sealed class CreateSystemSettingCommandHandler : IRequestHandler<CreateSystemSettingCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد تنظیم سیستم
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateSystemSettingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد تنظیم سیستم
    /// </summary>
    public async Task<Guid> Handle(CreateSystemSettingCommand request, CancellationToken cancellationToken)
    {
        // بررسی یکتایی کلید تنظیم
        var keyExists = await _context.SystemSettings
            .AnyAsync(ss => ss.Key == request.Key, cancellationToken);
        if (keyExists)
        {
            throw new ArgumentException($"تنظیم با کلید {request.Key} قبلاً وجود دارد");
        }

        // اعتبارسنجی نوع داده
        ValidateDataType(request.DataType, request.Value);

        var systemSetting = new SystemSetting
        {
            Id = Guid.NewGuid(),
            Key = request.Key,
            Value = request.Value,
            Description = request.Description ?? string.Empty,
            Category = request.Category,
            DataType = request.DataType,
            IsEditable = request.IsEditable,
            IsActive = request.IsActive,
            DefaultValue = request.DefaultValue ?? string.Empty,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.SystemSettings.Add(systemSetting);
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
