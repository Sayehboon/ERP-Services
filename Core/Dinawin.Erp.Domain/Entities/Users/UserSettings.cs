using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت تنظیمات کاربر
/// User settings entity
/// </summary>
public class UserSettings : BaseEntity
{
    /// <summary>
    /// شناسه کاربر
    /// User ID
    /// </summary>
    public required Guid UserId { get; set; }

    /// <summary>
    /// کاربر
    /// User
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// زبان ترجیحی
    /// Preferred language
    /// </summary>
    public string Language { get; set; } = "fa-IR";

    /// <summary>
    /// منطقه زمانی
    /// Timezone
    /// </summary>
    public string Timezone { get; set; } = "Asia/Tehran";

    /// <summary>
    /// فرمت تاریخ
    /// Date format
    /// </summary>
    public string DateFormat { get; set; } = "yyyy/MM/dd";

    /// <summary>
    /// فرمت زمان
    /// Time format
    /// </summary>
    public string TimeFormat { get; set; } = "HH:mm";

    /// <summary>
    /// واحد پول پیش‌فرض
    /// Default currency
    /// </summary>
    public string DefaultCurrency { get; set; } = "IRR";

    /// <summary>
    /// تم رابط کاربری
    /// UI theme
    /// </summary>
    public string Theme { get; set; } = "light";

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// Items per page
    /// </summary>
    public int ItemsPerPage { get; set; } = 25;

    /// <summary>
    /// دریافت اعلان‌های ایمیلی
    /// Receive email notifications
    /// </summary>
    public bool EmailNotifications { get; set; } = true;

    /// <summary>
    /// دریافت اعلان‌های پیامک
    /// Receive SMS notifications
    /// </summary>
    public bool SmsNotifications { get; set; } = false;

    /// <summary>
    /// دریافت اعلان‌های درون برنامه
    /// Receive in-app notifications
    /// </summary>
    public bool InAppNotifications { get; set; } = true;

    /// <summary>
    /// تنظیمات اضافی (JSON)
    /// Additional settings (JSON)
    /// </summary>
    public string? AdditionalSettings { get; set; }
}
