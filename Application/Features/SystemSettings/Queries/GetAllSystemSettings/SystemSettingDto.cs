namespace Dinawin.Erp.Application.Features.SystemSettings.Queries.GetAllSystemSettings;

/// <summary>
/// DTO تنظیم سیستم
/// </summary>
public class SystemSettingDto
{
    /// <summary>
    /// شناسه تنظیم سیستم
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// کلید تنظیم
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// مقدار تنظیم
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات تنظیم
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// دسته‌بندی تنظیم
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// نوع داده
    /// </summary>
    public string DataType { get; set; } = string.Empty;

    /// <summary>
    /// آیا قابل ویرایش است
    /// </summary>
    public bool IsEditable { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// مقدار پیش‌فرض
    /// </summary>
    public string DefaultValue { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
