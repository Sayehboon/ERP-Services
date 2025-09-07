using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemSettings.Commands.CreateSystemSetting;

/// <summary>
/// دستور ایجاد تنظیم سیستم
/// </summary>
public sealed class CreateSystemSettingCommand : IRequest<Guid>
{
    /// <summary>
    /// کلید تنظیم
    /// </summary>
    [Required(ErrorMessage = "کلید تنظیم الزامی است")]
    [StringLength(100, ErrorMessage = "کلید تنظیم نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// مقدار تنظیم
    /// </summary>
    [Required(ErrorMessage = "مقدار تنظیم الزامی است")]
    [StringLength(1000, ErrorMessage = "مقدار تنظیم نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات تنظیم
    /// </summary>
    [StringLength(500, ErrorMessage = "توضیحات تنظیم نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// دسته‌بندی تنظیم
    /// </summary>
    [Required(ErrorMessage = "دسته‌بندی تنظیم الزامی است")]
    [StringLength(50, ErrorMessage = "دسته‌بندی تنظیم نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Category { get; set; } = "General";

    /// <summary>
    /// نوع داده
    /// </summary>
    [Required(ErrorMessage = "نوع داده الزامی است")]
    [StringLength(20, ErrorMessage = "نوع داده نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string DataType { get; set; } = "String";

    /// <summary>
    /// آیا قابل ویرایش است
    /// </summary>
    public bool IsEditable { get; set; } = true;

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// مقدار پیش‌فرض
    /// </summary>
    [StringLength(1000, ErrorMessage = "مقدار پیش‌فرض نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string? DefaultValue { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }
}
