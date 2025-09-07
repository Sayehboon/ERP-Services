using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemSettings.Commands.ResetSystemSettings;

/// <summary>
/// دستور بازنشانی تنظیمات سیستم
/// </summary>
public sealed class ResetSystemSettingsCommand : IRequest<bool>
{
    /// <summary>
    /// دسته‌بندی تنظیمات (اختیاری - اگر خالی باشد تمام تنظیمات بازنشانی می‌شوند)
    /// </summary>
    [StringLength(50, ErrorMessage = "دسته‌بندی تنظیمات نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? Category { get; set; }

    /// <summary>
    /// شناسه کاربر بازنشانی کننده
    /// </summary>
    public Guid? ResetBy { get; set; }
}
