namespace Dinawin.Erp.Application.Features.Units.Queries.GetUnitById;

/// <summary>
/// DTO واحد اندازه‌گیری
/// </summary>
public class UnitDto
{
    /// <summary>
    /// شناسه واحد اندازه‌گیری
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام واحد اندازه‌گیری
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد واحد اندازه‌گیری
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نماد واحد اندازه‌گیری
    /// </summary>
    public string? Symbol { get; set; }

    /// <summary>
    /// توضیحات واحد اندازه‌گیری
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// نوع واحد اندازه‌گیری
    /// </summary>
    public string? UnitType { get; set; }

    /// <summary>
    /// ضریب تبدیل به واحد پایه
    /// </summary>
    public decimal ConversionFactor { get; set; }

    /// <summary>
    /// شناسه واحد پایه
    /// </summary>
    public Guid? BaseUnitId { get; set; }

    /// <summary>
    /// نام واحد پایه
    /// </summary>
    public string? BaseUnitName { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// ترتیب نمایش
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// تعداد کالاهای مرتبط
    /// </summary>
    public int ProductCount { get; set; }

    /// <summary>
    /// تعداد واحدهای وابسته
    /// </summary>
    public int DependentUnitCount { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
