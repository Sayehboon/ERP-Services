namespace Dinawin.Erp.Application.Features.Products.Queries.Dtos;

/// <summary>
/// DTO کالا
/// Product Data Transfer Object
/// </summary>
public class ProductDto
{
    /// <summary>
    /// شناسه کالا
    /// Product ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// کد SKU کالا
    /// Product SKU code
    /// </summary>
    public string Sku { get; set; } = string.Empty;

    /// <summary>
    /// نام کالا
    /// Product name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات کالا
    /// Product description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// شناسه برند
    /// Brand ID
    /// </summary>
    public Guid? BrandId { get; set; }

    /// <summary>
    /// نام برند
    /// Brand name
    /// </summary>
    public string BrandName { get; set; }

    /// <summary>
    /// شناسه دسته‌بندی
    /// Category ID
    /// </summary>
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// نام دسته‌بندی
    /// Category name
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// شناسه واحد پایه
    /// Base unit of measure ID
    /// </summary>
    public Guid? BaseUomId { get; set; }

    /// <summary>
    /// نام واحد پایه
    /// Base unit of measure name
    /// </summary>
    public string BaseUomName { get; set; }

    /// <summary>
    /// قیمت خرید
    /// Purchase price
    /// </summary>
    public decimal? PriceBuy { get; set; }

    /// <summary>
    /// قیمت فروش
    /// Selling price
    /// </summary>
    public decimal? PriceSell { get; set; }

    /// <summary>
    /// موجودی کل
    /// Total stock quantity
    /// </summary>
    public decimal StockQuantity { get; set; }

    /// <summary>
    /// حداقل موجودی
    /// Minimum stock level
    /// </summary>
    public decimal MinStockLevel { get; set; }

    /// <summary>
    /// حداکثر موجودی
    /// Maximum stock level
    /// </summary>
    public decimal MaxStockLevel { get; set; }

    /// <summary>
    /// نقطه سفارش مجدد
    /// Reorder point
    /// </summary>
    public decimal ReorderPoint { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// Creation date
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ بروزرسانی
    /// Last update date
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// DTO برند
/// Brand Data Transfer Object
/// </summary>
public class BrandDto
{
    /// <summary>
    /// شناسه برند
    /// Brand ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام برند
    /// Brand name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات برند
    /// Brand description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// تعداد کالاهای مرتبط
    /// Number of related products
    /// </summary>
    public int ProductCount { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// Creation date
    /// </summary>
    public DateTime CreatedAt { get; set; }
}

/// <summary>
/// DTO دسته‌بندی
/// Category Data Transfer Object
/// </summary>
public class CategoryDto
{
    /// <summary>
    /// شناسه دسته‌بندی
    /// Category ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام دسته‌بندی
    /// Category name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات دسته‌بندی
    /// Category description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// شناسه دسته‌بندی والد
    /// Parent category ID
    /// </summary>
    public Guid? ParentCategoryId { get; set; }

    /// <summary>
    /// نام دسته‌بندی والد
    /// Parent category name
    /// </summary>
    public string ParentCategoryName { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// ترتیب نمایش
    /// Display order
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// تعداد کالاهای مرتبط
    /// Number of related products
    /// </summary>
    public int ProductCount { get; set; }

    /// <summary>
    /// تعداد زیردسته‌ها
    /// Number of subcategories
    /// </summary>
    public int SubcategoryCount { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// Creation date
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
