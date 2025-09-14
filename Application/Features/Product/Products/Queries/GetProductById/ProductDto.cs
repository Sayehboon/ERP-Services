namespace Dinawin.Erp.Application.Features.Product.Products.Queries.GetProductById;

/// <summary>
/// DTO محصول
/// </summary>
public class ProductDto
{
    /// <summary>
    /// شناسه محصول
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام محصول
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد محصول
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// شناسه برند
    /// </summary>
    public Guid? BrandId { get; set; }

    /// <summary>
    /// نام برند
    /// </summary>
    public string BrandName { get; set; }

    /// <summary>
    /// شناسه دسته‌بندی
    /// </summary>
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// نام دسته‌بندی
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// شناسه مدل
    /// </summary>
    public Guid? ModelId { get; set; }

    /// <summary>
    /// نام مدل
    /// </summary>
    public string ModelName { get; set; }

    /// <summary>
    /// شناسه تریم
    /// </summary>
    public Guid? TrimId { get; set; }

    /// <summary>
    /// نام تریم
    /// </summary>
    public string TrimName { get; set; }

    /// <summary>
    /// شناسه سال
    /// </summary>
    public Guid? YearId { get; set; }

    /// <summary>
    /// سال
    /// </summary>
    public int? Year { get; set; }

    /// <summary>
    /// شناسه واحد
    /// </summary>
    public Guid? UnitId { get; set; }

    /// <summary>
    /// نام واحد
    /// </summary>
    public string UnitName { get; set; }

    /// <summary>
    /// شناسه UOM
    /// </summary>
    public Guid? UomId { get; set; }

    /// <summary>
    /// نام UOM
    /// </summary>
    public string UomName { get; set; }

    /// <summary>
    /// توضیحات محصول
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// قیمت خرید
    /// </summary>
    public decimal PurchasePrice { get; set; }

    /// <summary>
    /// قیمت فروش
    /// </summary>
    public decimal SalePrice { get; set; }

    /// <summary>
    /// قیمت عمده‌فروشی
    /// </summary>
    public decimal WholesalePrice { get; set; }

    /// <summary>
    /// حداقل موجودی
    /// </summary>
    public decimal MinStock { get; set; }

    /// <summary>
    /// حداکثر موجودی
    /// </summary>
    public decimal MaxStock { get; set; }

    /// <summary>
    /// موجودی فعلی
    /// </summary>
    public decimal CurrentStock { get; set; }

    /// <summary>
    /// وزن محصول
    /// </summary>
    public decimal? Weight { get; set; }

    /// <summary>
    /// ابعاد محصول
    /// </summary>
    public string Dimensions { get; set; }

    /// <summary>
    /// رنگ محصول
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// نوع محصول
    /// </summary>
    public string ProductType { get; set; }

    /// <summary>
    /// وضعیت محصول
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// آیا قابل فروش است
    /// </summary>
    public bool IsSellable { get; set; }

    /// <summary>
    /// آیا قابل خرید است
    /// </summary>
    public bool IsPurchasable { get; set; }

    /// <summary>
    /// آیا قابل تولید است
    /// </summary>
    public bool IsManufacturable { get; set; }

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