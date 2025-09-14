using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemSettings.Commands.UpdateSystemSettingByKey;

/// <summary>
/// دستور به‌روزرسانی تنظیم سیستم بر اساس کلید
/// </summary>
public sealed class UpdateSystemSettingByKeyCommand : IRequest<bool>
{
    /// <summary>
    /// کلید تنظیم
    /// </summary>
    [Required(ErrorMessage = "کلید تنظیم الزامی است")]
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// مقدار جدید تنظیم
    /// </summary>
    [Required(ErrorMessage = "مقدار تنظیم الزامی است")]
    [StringLength(1000, ErrorMessage = "مقدار تنظیم نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
