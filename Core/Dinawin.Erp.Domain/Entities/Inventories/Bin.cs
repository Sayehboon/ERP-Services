namespace Dinawin.Erp.Domain.Entities.Inventories;

using Dinawin.Erp.Domain.Common;

/// <summary>
/// موجودیت محل/بین انبار
/// Inventory bin entity
/// </summary>
public class Bin : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// کد بین
    /// Bin code
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// نام بین
    /// Bin name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// شرح
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// راهرو
    /// Aisle
    /// </summary>
    public string? Aisle { get; set; }

    /// <summary>
    /// قفسه
    /// Shelf
    /// </summary>
    public string? Shelf { get; set; }

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شناسه انبار
    /// Warehouse ID
    /// </summary>
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// انبار
    /// Warehouse
    /// </summary>
    public Warehouse Warehouse { get; set; } = null!;

    /// <summary>
    /// موجودی‌های این بین
    /// Inventories in this bin
    /// </summary>
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    public string? BinType { get; set; }
    public decimal? Capacity { get; set; }
    public string? CapacityUnit { get; set; }
    public decimal? Width { get; set; }
    public decimal? Length { get; set; }
    public decimal? Height { get; set; }
    public string? Location { get; set; }
}
