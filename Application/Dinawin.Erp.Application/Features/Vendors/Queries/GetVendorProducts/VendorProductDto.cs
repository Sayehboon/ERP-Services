namespace Dinawin.Erp.Application.Features.Vendors.Queries.GetVendorProducts;

/// <summary>
/// DTO محصول تامین‌کننده
/// </summary>
public class VendorProductDto
{
    /// <summary>
    /// شناسه محصول
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام محصول
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// کد محصول
    /// </summary>
    public string ProductCode { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات محصول
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه دسته‌بندی
    /// </summary>
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// نام دسته‌بندی
    /// </summary>
    public string? CategoryName { get; set; }

    /// <summary>
    /// شناسه واحد اندازه‌گیری
    /// </summary>
    public Guid? UomId { get; set; }

    /// <summary>
    /// نام واحد اندازه‌گیری
    /// </summary>
    public string? UomName { get; set; }

    /// <summary>
    /// قیمت خرید از تامین‌کننده
    /// </summary>
    public decimal? PurchasePrice { get; set; }

    /// <summary>
    /// قیمت فروش
    /// </summary>
    public decimal? SalePrice { get; set; }

    /// <summary>
    /// حداقل موجودی
    /// </summary>
    public decimal? MinStockLevel { get; set; }

    /// <summary>
    /// حداکثر موجودی
    /// </summary>
    public decimal? MaxStockLevel { get; set; }

    /// <summary>
    /// موجودی فعلی
    /// </summary>
    public decimal? CurrentStock { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// آیا در دسترس است
    /// </summary>
    public bool IsAvailable { get; set; }

    /// <summary>
    /// تاریخ آخرین خرید
    /// </summary>
    public DateTime? LastPurchaseDate { get; set; }

    /// <summary>
    /// تاریخ آخرین فروش
    /// </summary>
    public DateTime? LastSaleDate { get; set; }

    /// <summary>
    /// تعداد فروش در ماه جاری
    /// </summary>
    public int? SalesThisMonth { get; set; }

    /// <summary>
    /// تعداد فروش در ماه گذشته
    /// </summary>
    public int? SalesLastMonth { get; set; }

    /// <summary>
    /// تصویر محصول
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// برچسب‌های محصول
    /// </summary>
    public List<string> Tags { get; set; } = new();

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
