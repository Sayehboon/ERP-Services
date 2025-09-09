namespace Dinawin.Erp.Application.Features.Uoms.Queries.GetUomById;

/// <summary>
/// DTO واحد اندازه‌گیری
/// </summary>
public class UomDto
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
    /// نماد واحد اندازه‌گیری
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// کد واحد اندازه‌گیری
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نوع واحد اندازه‌گیری
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// ضریب تبدیل به واحد پایه
    /// </summary>
    public decimal ConversionFactor { get; set; } = 1;

    /// <summary>
    /// شناسه واحد پایه
    /// </summary>
    public Guid? BaseUomId { get; set; }

    /// <summary>
    /// نام واحد پایه
    /// </summary>
    public string? BaseUomName { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}