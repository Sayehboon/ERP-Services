namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetInventoryStats;

/// <summary>
/// مدل انتقال داده آمار موجودی
/// </summary>
public sealed class InventoryStatsDto
{
    /// <summary>
    /// تعداد کل محصولات
    /// </summary>
    public int TotalProducts { get; set; }

    /// <summary>
    /// تعداد محصولات با موجودی
    /// </summary>
    public int InStockProducts { get; set; }

    /// <summary>
    /// تعداد محصولات با موجودی کم
    /// </summary>
    public int LowStockProducts { get; set; }

    /// <summary>
    /// تعداد محصولات بدون موجودی
    /// </summary>
    public int OutOfStockProducts { get; set; }

    /// <summary>
    /// ارزش کل موجودی
    /// </summary>
    public decimal TotalInventoryValue { get; set; }

    /// <summary>
    /// تعداد کل انبارها
    /// </summary>
    public int TotalWarehouses { get; set; }

    /// <summary>
    /// تعداد کل مکان‌های انبار
    /// </summary>
    public int TotalBins { get; set; }

    /// <summary>
    /// آمار موجودی بر اساس دسته‌بندی
    /// </summary>
    public List<CategoryInventoryStatsDto> CategoryStats { get; set; } = new();

    /// <summary>
    /// آمار موجودی بر اساس انبار
    /// </summary>
    public List<WarehouseInventoryStatsDto> WarehouseStats { get; set; } = new();

    /// <summary>
    /// محصولات با موجودی کم
    /// </summary>
    public List<LowStockProductDto> LowStockProducts { get; set; } = new();
}

/// <summary>
/// مدل آمار موجودی بر اساس دسته‌بندی
/// </summary>
public sealed class CategoryInventoryStatsDto
{
    /// <summary>
    /// شناسه دسته‌بندی
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// نام دسته‌بندی
    /// </summary>
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// تعداد محصولات
    /// </summary>
    public int ProductCount { get; set; }

    /// <summary>
    /// مجموع موجودی
    /// </summary>
    public decimal TotalQuantity { get; set; }

    /// <summary>
    /// ارزش موجودی
    /// </summary>
    public decimal InventoryValue { get; set; }

    /// <summary>
    /// درصد از کل
    /// </summary>
    public decimal Percentage { get; set; }
}

/// <summary>
/// مدل آمار موجودی بر اساس انبار
/// </summary>
public sealed class WarehouseInventoryStatsDto
{
    /// <summary>
    /// شناسه انبار
    /// </summary>
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// نام انبار
    /// </summary>
    public string WarehouseName { get; set; } = string.Empty;

    /// <summary>
    /// تعداد محصولات
    /// </summary>
    public int ProductCount { get; set; }

    /// <summary>
    /// مجموع موجودی
    /// </summary>
    public decimal TotalQuantity { get; set; }

    /// <summary>
    /// ارزش موجودی
    /// </summary>
    public decimal InventoryValue { get; set; }

    /// <summary>
    /// درصد از کل
    /// </summary>
    public decimal Percentage { get; set; }
}

/// <summary>
/// مدل محصول با موجودی کم
/// </summary>
public sealed class LowStockProductDto
{
    /// <summary>
    /// شناسه محصول
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// نام محصول
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// کد محصول
    /// </summary>
    public string ProductCode { get; set; } = string.Empty;

    /// <summary>
    /// موجودی فعلی
    /// </summary>
    public decimal CurrentQuantity { get; set; }

    /// <summary>
    /// حداقل موجودی
    /// </summary>
    public decimal ReorderLevel { get; set; }

    /// <summary>
    /// نام انبار
    /// </summary>
    public string WarehouseName { get; set; } = string.Empty;

    /// <summary>
    /// نام دسته‌بندی
    /// </summary>
    public string CategoryName { get; set; } = string.Empty;
}
