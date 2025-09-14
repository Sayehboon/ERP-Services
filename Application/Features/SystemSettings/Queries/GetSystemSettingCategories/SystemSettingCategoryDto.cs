namespace Dinawin.Erp.Application.Features.SystemSettings.Queries.GetSystemSettingCategories;

/// <summary>
/// DTO دسته‌بندی تنظیمات سیستم
/// </summary>
public class SystemSettingCategoryDto
{
    /// <summary>
    /// نام دسته‌بندی
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام نمایشی دسته‌بندی
    /// </summary>
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات دسته‌بندی
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// تعداد تنظیمات در این دسته‌بندی
    /// </summary>
    public int SettingsCount { get; set; }
}
