namespace Dinawin.Erp.Application.Features.Inventories.Bins.Queries.GetAllBins;

/// <summary>
/// مدل انتقال داده مکان
/// </summary>
public sealed class BinDto
{
    /// <summary>
    /// شناسه مکان
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام مکان
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد مکان
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// شناسه انبار
    /// </summary>
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// نام انبار
    /// </summary>
    public string WarehouseName { get; set; } = string.Empty;

    /// <summary>
    /// نوع مکان
    /// </summary>
    public string? BinType { get; set; }

    /// <summary>
    /// ظرفیت مکان
    /// </summary>
    public decimal? Capacity { get; set; }

    /// <summary>
    /// واحد ظرفیت
    /// </summary>
    public string? CapacityUnit { get; set; }

    /// <summary>
    /// عرض مکان (متر)
    /// </summary>
    public decimal? Width { get; set; }

    /// <summary>
    /// طول مکان (متر)
    /// </summary>
    public decimal? Length { get; set; }

    /// <summary>
    /// ارتفاع مکان (متر)
    /// </summary>
    public decimal? Height { get; set; }

    /// <summary>
    /// موقعیت مکان در انبار
    /// </summary>
    public string? Location { get; set; }

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
