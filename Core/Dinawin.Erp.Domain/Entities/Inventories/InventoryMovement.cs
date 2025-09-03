using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Products;
using Dinawin.Erp.Domain.ValueObjects;

namespace Dinawin.Erp.Domain.Entities.Inventories;

/// <summary>
/// موجودیت حرکت موجودی
/// Inventory movement entity
/// </summary>
public class InventoryMovement : BaseEntity
{
    /// <summary>
    /// شناسه کالا
    /// Product ID
    /// </summary>
    public required Guid ProductId { get; set; }

    /// <summary>
    /// کالا
    /// Product
    /// </summary>
    public Product Product { get; set; } = null!;

    /// <summary>
    /// شناسه انبار
    /// Warehouse ID
    /// </summary>
    public required Guid WarehouseId { get; set; }

    /// <summary>
    /// انبار
    /// Warehouse
    /// </summary>
    public Warehouse Warehouse { get; set; } = null!;

    /// <summary>
    /// نوع حرکت
    /// Movement type
    /// </summary>
    public MovementType Type { get; set; }

    /// <summary>
    /// مقدار حرکت (مثبت برای ورود، منفی برای خروج)
    /// Movement quantity (positive for inbound, negative for outbound)
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// قیمت واحد
    /// Unit cost
    /// </summary>
    public Money? UnitCost { get; set; }

    /// <summary>
    /// مجموع ارزش حرکت
    /// Total movement value
    /// </summary>
    public Money? TotalValue { get; set; }

    /// <summary>
    /// موجودی قبل از حرکت
    /// Balance before movement
    /// </summary>
    public decimal BalanceBefore { get; set; }

    /// <summary>
    /// موجودی بعد از حرکت
    /// Balance after movement
    /// </summary>
    public decimal BalanceAfter { get; set; }

    /// <summary>
    /// شماره مرجع
    /// Reference number
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// نوع سند مرجع
    /// Reference document type
    /// </summary>
    public string? ReferenceType { get; set; }

    /// <summary>
    /// شناسه سند مرجع
    /// Reference document ID
    /// </summary>
    public Guid? ReferenceId { get; set; }

    /// <summary>
    /// دلیل حرکت
    /// Movement reason
    /// </summary>
    public required string Reason { get; set; }

    /// <summary>
    /// یادداشت
    /// Notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// تاریخ حرکت
    /// Movement date
    /// </summary>
    public DateTime MovementDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// شناسه موجودی مرتبط
    /// Related inventory ID
    /// </summary>
    public required Guid InventoryId { get; set; }

    /// <summary>
    /// موجودی مرتبط
    /// Related inventory
    /// </summary>
    public Inventory Inventory { get; set; } = null!;
}

/// <summary>
/// انواع حرکت موجودی
/// Inventory movement types
/// </summary>
public enum MovementType
{
    /// <summary>
    /// ورود خرید
    /// Purchase receipt
    /// </summary>
    PurchaseReceipt = 1,

    /// <summary>
    /// خروج فروش
    /// Sales issue
    /// </summary>
    SalesIssue = 2,

    /// <summary>
    /// تعدیل موجودی
    /// Stock adjustment
    /// </summary>
    StockAdjustment = 3,

    /// <summary>
    /// انتقال بین انبارها
    /// Transfer between warehouses
    /// </summary>
    Transfer = 4,

    /// <summary>
    /// مرجوعی خرید
    /// Purchase return
    /// </summary>
    PurchaseReturn = 5,

    /// <summary>
    /// مرجوعی فروش
    /// Sales return
    /// </summary>
    SalesReturn = 6,

    /// <summary>
    /// تولید
    /// Production
    /// </summary>
    Production = 7,

    /// <summary>
    /// مصرف تولید
    /// Production consumption
    /// </summary>
    ProductionConsumption = 8,

    /// <summary>
    /// ضایعات
    /// Waste/Scrap
    /// </summary>
    Waste = 9,

    /// <summary>
    /// موجودی اولیه
    /// Opening balance
    /// </summary>
    OpeningBalance = 10
}
