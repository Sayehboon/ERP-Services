namespace Dinawin.Erp.Application.Features.Uoms.Queries.GetAllUoms;

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
    /// کد واحد اندازه‌گیری
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نماد واحد اندازه‌گیری
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// نوع واحد اندازه‌گیری
    /// </summary>
    public string UomType { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات
    /// </summary>
    public string Description { get; set; }

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
