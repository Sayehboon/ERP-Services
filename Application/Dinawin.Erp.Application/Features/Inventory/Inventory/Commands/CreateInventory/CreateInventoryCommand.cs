using MediatR;

namespace Dinawin.Erp.Application.Features.Inventory.Inventory.Commands.CreateInventory;

/// <summary>
/// دستور ایجاد موجودی جدید
/// </summary>
public class CreateInventoryCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه محصول
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// شناسه انبار
    /// </summary>
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// شناسه مکان انبار (بین)
    /// </summary>
    public Guid? BinId { get; set; }

    /// <summary>
    /// تعداد موجود
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// حداقل موجودی
    /// </summary>
    public int? MinimumStock { get; set; }

    /// <summary>
    /// حداکثر موجودی
    /// </summary>
    public int? MaximumStock { get; set; }

    /// <summary>
    /// قیمت میانگین
    /// </summary>
    public decimal? AveragePrice { get; set; }

    /// <summary>
    /// تاریخ آخرین ورود
    /// </summary>
    public DateTime? LastInDate { get; set; }

    /// <summary>
    /// تاریخ آخرین خروج
    /// </summary>
    public DateTime? LastOutDate { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// یادداشت‌ها
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// </summary>
    public Guid CreatedByUserId { get; set; }
}
