using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

/// <summary>
/// پیکربندی موجودیت رزرو موجودی
/// Inventory Reservation entity configuration
/// </summary>
public class InventoryReservationConfiguration : IEntityTypeConfiguration<InventoryReservation>
{
    public void Configure(EntityTypeBuilder<InventoryReservation> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Status).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Type).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.ReferenceNumber).HasMaxLength(100);
        builder.Property(e => e.ReferenceType).HasMaxLength(50);

        builder.Property(e => e.ReservedQuantity).HasColumnType("decimal(18,4)");
        builder.Property(e => e.Quantity).HasColumnType("decimal(18,4)");

        builder.HasIndex(e => e.ProductId);
        builder.HasIndex(e => e.WarehouseId);
        builder.HasIndex(e => e.ReservationDate);
        builder.HasIndex(e => e.Status);
    }
}
