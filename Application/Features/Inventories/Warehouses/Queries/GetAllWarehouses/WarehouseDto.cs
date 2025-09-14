namespace Dinawin.Erp.Application.Features.Inventories.Warehouses.Queries.GetAllWarehouses;

/// <summary>
/// DTO انبار
/// </summary>
public class WarehouseDto
{
    /// <summary>
    /// شناسه انبار
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام انبار
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد انبار
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// آدرس انبار
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// ایمیل
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// نام مسئول انبار
    /// </summary>
    public string ManagerName { get; set; }

    /// <summary>
    /// ظرفیت انبار
    /// </summary>
    public decimal? Capacity { get; set; }

    /// <summary>
    /// واحد ظرفیت
    /// </summary>
    public string CapacityUnit { get; set; }

    /// <summary>
    /// نوع انبار
    /// </summary>
    public string WarehouseType { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// تعداد مکان‌ها
    /// </summary>
    public int BinsCount { get; set; }

    /// <summary>
    /// تعداد محصولات موجود
    /// </summary>
    public int ProductsCount { get; set; }

    /// <summary>
    /// ارزش کل موجودی
    /// </summary>
    public decimal TotalInventoryValue { get; set; }

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
