using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Inventories;
using Dinawin.Erp.Domain.ValueObjects;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// موجودیت کالا
/// Product entity
/// </summary>
public class Product : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// کد SKU کالا
    /// Product SKU code
    /// </summary>
    public required string Sku { get; set; }

    /// <summary>
    /// نام کالا
    /// Product name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// توضیحات کالا
    /// Product description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه برند
    /// Brand ID
    /// </summary>
    public Guid? BrandId { get; set; }

    /// <summary>
    /// برند
    /// Brand
    /// </summary>
    public Brand? Brand { get; set; }

    /// <summary>
    /// شناسه دسته‌بندی
    /// Category ID
    /// </summary>
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// دسته‌بندی
    /// Category
    /// </summary>
    public Category? Category { get; set; }

    /// <summary>
    /// شناسه واحد پایه
    /// Base unit of measure ID
    /// </summary>
    public Guid? BaseUomId { get; set; }

    /// <summary>
    /// واحد پایه
    /// Base unit of measure
    /// </summary>
    public UnitOfMeasure? BaseUom { get; set; }

    /// <summary>
    /// قیمت خرید
    /// Purchase price
    /// </summary>
    public Money? PurchasePrice { get; set; }

    /// <summary>
    /// قیمت فروش
    /// Selling price
    /// </summary>
    public Money? SellingPrice { get; set; }

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
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// نوع کالا
    /// Product type
    /// </summary>
    public ProductType Type { get; set; } = ProductType.Physical;

    /// <summary>
    /// وزن کالا
    /// Product weight
    /// </summary>
    public Weight? Weight { get; set; }

    /// <summary>
    /// ابعاد کالا
    /// Product dimensions
    /// </summary>
    public Dimensions? Dimensions { get; set; }

    /// <summary>
    /// موجودی‌های کالا در انبارها
    /// Product inventories in warehouses
    /// </summary>
    public ICollection<Inventory> Inventories { get; set; } = [];

    /// <summary>
    /// حرکات موجودی کالا
    /// Product inventory movements
    /// </summary>
    public ICollection<InventoryMovement> InventoryMovements { get; set; } = [];
}

/// <summary>
/// انواع کالا
/// Product types
/// </summary>
public enum ProductType
{
    /// <summary>
    /// کالای فیزیکی
    /// Physical product
    /// </summary>
    Physical = 1,

    /// <summary>
    /// خدمات
    /// Service
    /// </summary>
    Service = 2,

    /// <summary>
    /// کالای دیجیتال
    /// Digital product
    /// </summary>
    Digital = 3
}
