namespace Dinawin.Erp.Domain.Entities.Systems;

using Dinawin.Erp.Domain.Common;

/// <summary>
/// موجودیت تنظیمات سیستم
/// System settings entity
/// </summary>
public class SystemSetting : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// دسته‌بندی تنظیمات
    /// Settings category
    /// </summary>
    public required string Category { get; set; }

    /// <summary>
    /// کلید تنظیمات
    /// Settings key
    /// </summary>
    public required string Key { get; set; }

    /// <summary>
    /// مقدار تنظیمات (JSON)
    /// Settings value (JSON)
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public string BusinessId { get; set; } = "default";

    ///// <summary>
    ///// شناسه کاربر به‌روزرسانی‌کننده
    ///// Updated by user ID
    ///// </summary>
    //public Guid? UpdatedBy { get; set; }
}
