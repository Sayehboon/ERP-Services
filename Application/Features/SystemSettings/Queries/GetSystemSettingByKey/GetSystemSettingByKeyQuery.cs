using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemSettings.Queries.GetSystemSettingByKey;

/// <summary>
/// پرس‌وجو دریافت تنظیم سیستم بر اساس کلید
/// </summary>
public sealed class GetSystemSettingByKeyQuery : IRequest<SystemSettingDto>
{
    /// <summary>
    /// کلید تنظیم
    /// </summary>
    [Required(ErrorMessage = "کلید تنظیم الزامی است")]
    public string Key { get; set; } = string.Empty;
}
