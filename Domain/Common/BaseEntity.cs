namespace Dinawin.Erp.Domain.Common;

/// <summary>
/// کلاس پایه برای تمام موجودیت‌ها
/// Base class for all entities
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// شناسه یکتا
    /// Unique identifier
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// تاریخ ایجاد
    /// Creation date
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// تاریخ آخرین بروزرسانی
    /// Last updated date
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Creator user ID
    /// </summary>
    public Guid? CreatedBy { get; init; }

    /// <summary>
    /// شناسه کاربر بروزرسان
    /// Updater user ID
    /// </summary>
    public Guid? UpdatedBy { get; set; }

    /// <summary>
    /// وضعیت حذف نرم
    /// Soft delete status
    /// </summary>
    public bool IsDeleted { get; set; } = false;

    /// <summary>
    /// تاریخ حذف
    /// Deletion date
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    /// <summary>
    /// شناسه کاربر حذف‌کننده
    /// Deleter user ID
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
