using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemSettings.Commands.UpdateSystemSettingsBatch;

/// <summary>
/// دستور به‌روزرسانی دسته‌ای تنظیمات سیستم
/// </summary>
public sealed class UpdateSystemSettingsBatchCommand : IRequest<bool>
{
    /// <summary>
    /// لیست تنظیمات برای به‌روزرسانی
    /// </summary>
    [Required(ErrorMessage = "لیست تنظیمات الزامی است")]
    public List<SystemSettingUpdateItem> Settings { get; set; } = new();

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}

/// <summary>
/// آیتم به‌روزرسانی تنظیم سیستم
/// </summary>
public class SystemSettingUpdateItem
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
}
