namespace Dinawin.Erp.Domain.Enums;

/// <summary>
/// انواع حرکت موجودی
/// Inventory Movement Types
/// </summary>
public enum InventoryMovementType
{
    /// <summary>
    /// ورود
    /// In
    /// </summary>
    In = 1,

    /// <summary>
    /// خروج
    /// Out
    /// </summary>
    Out = 2,

    /// <summary>
    /// انتقال
    /// Transfer
    /// </summary>
    Transfer = 3,

    /// <summary>
    /// تعدیل
    /// Adjustment
    /// </summary>
    Adjustment = 4,

    /// <summary>
    /// برگشت
    /// Return
    /// </summary>
    Return = 5,

    /// <summary>
    /// تولید
    /// Production
    /// </summary>
    Production = 6,

    /// <summary>
    /// مصرف
    /// Consumption
    /// </summary>
    Consumption = 7,

    /// <summary>
    /// انقضا
    /// Expiry
    /// </summary>
    Expiry = 8,

    /// <summary>
    /// ضایعات
    /// Waste
    /// </summary>
    Waste = 9,

    /// <summary>
    /// رزرو
    /// Reservation
    /// </summary>
    Reservation = 10,

    /// <summary>
    /// آزادسازی رزرو
    /// Reservation Release
    /// </summary>
    ReservationRelease = 11
}
