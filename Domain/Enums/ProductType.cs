namespace Dinawin.Erp.Domain.Enums;

/// <summary>
/// انواع محصول
/// Product types
/// </summary>
public enum ProductType
{
    /// <summary>
    /// کالای فیزیکی
    /// Physical product
    /// </summary>
    Physical = 1,

    /// <summary>
    /// کالای دیجیتال
    /// Digital product
    /// </summary>
    Digital = 2,

    /// <summary>
    /// خدمات
    /// Service
    /// </summary>
    Service = 3,

    /// <summary>
    /// قطعه یدکی
    /// Spare part
    /// </summary>
    SparePart = 4,

    /// <summary>
    /// لوازم جانبی
    /// Accessory
    /// </summary>
    Accessory = 5,

    /// <summary>
    /// مواد اولیه
    /// Raw material
    /// </summary>
    RawMaterial = 6,

    /// <summary>
    /// محصول نیمه‌ساخته
    /// Semi-finished product
    /// </summary>
    SemiFinished = 7,

    /// <summary>
    /// محصول نهایی
    /// Finished product
    /// </summary>
    Finished = 8
}
