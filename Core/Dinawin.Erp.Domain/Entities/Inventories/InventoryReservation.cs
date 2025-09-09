using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Inventories;

/// <summary>
/// موجودیت رزرو موجودی
/// Inventory Reservation entity
/// </summary>
public class InventoryReservation : BaseEntity
{
    /// <summary>
    /// شناسه محصول
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// شناسه انبار
    /// Warehouse ID
    /// </summary>
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// تعداد رزرو شده
    /// Reserved quantity
    /// </summary>
    public decimal ReservedQuantity { get; set; }

    /// <summary>
    /// تاریخ رزرو
    /// Reservation date
    /// </summary>
    public DateTime ReservationDate { get; set; }

    /// <summary>
    /// تاریخ انقضا رزرو
    /// Reservation expiry date
    /// </summary>
    public DateTime? ExpiryDate { get; set; }

    /// <summary>
    /// وضعیت رزرو
    /// Reservation status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// نوع رزرو
    /// Reservation type
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// توضیحات رزرو
    /// Reservation description
    /// </summary>
    public string? Description { get; set; }
    public Guid? BinId { get; set; }
    public string? ReferenceNumber { get; set; }
    public string? ReferenceType { get; set; }
    public Guid? ReferenceId { get; set; }
    public decimal Quantity { get; set; }
    public DateTime ReleasedAt { get; set; }
    public Guid? ReleasedBy { get; set; }
    public Guid? ReservedBy { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>

}
