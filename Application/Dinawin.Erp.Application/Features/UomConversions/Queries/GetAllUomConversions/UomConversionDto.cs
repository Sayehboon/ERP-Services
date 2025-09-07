namespace Dinawin.Erp.Application.Features.UomConversions.Queries.GetAllUomConversions;

/// <summary>
/// DTO تبدیل واحد اندازه‌گیری
/// </summary>
public class UomConversionDto
{
    /// <summary>
    /// شناسه تبدیل واحد اندازه‌گیری
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه واحد اندازه‌گیری مبدا
    /// </summary>
    public Guid FromUomId { get; set; }

    /// <summary>
    /// نام واحد اندازه‌گیری مبدا
    /// </summary>
    public string? FromUomName { get; set; }

    /// <summary>
    /// کد واحد اندازه‌گیری مبدا
    /// </summary>
    public string? FromUomCode { get; set; }

    /// <summary>
    /// نماد واحد اندازه‌گیری مبدا
    /// </summary>
    public string? FromUomSymbol { get; set; }

    /// <summary>
    /// شناسه واحد اندازه‌گیری مقصد
    /// </summary>
    public Guid ToUomId { get; set; }

    /// <summary>
    /// نام واحد اندازه‌گیری مقصد
    /// </summary>
    public string? ToUomName { get; set; }

    /// <summary>
    /// کد واحد اندازه‌گیری مقصد
    /// </summary>
    public string? ToUomCode { get; set; }

    /// <summary>
    /// نماد واحد اندازه‌گیری مقصد
    /// </summary>
    public string? ToUomSymbol { get; set; }

    /// <summary>
    /// ضریب تبدیل
    /// </summary>
    public decimal ConversionFactor { get; set; }

    /// <summary>
    /// نام تبدیل
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

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
