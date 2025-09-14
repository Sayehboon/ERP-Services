using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Commands.UpdateInventory;

/// <summary>
/// دستور به‌روزرسانی موجودی
/// </summary>
public sealed class UpdateInventoryCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه موجودی
    /// </summary>
    [Required(ErrorMessage = "شناسه موجودی الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه محصول
    /// </summary>
    [Required(ErrorMessage = "شناسه محصول الزامی است")]
    public Guid ProductId { get; set; }

    /// <summary>
    /// شناسه انبار
    /// </summary>
    [Required(ErrorMessage = "شناسه انبار الزامی است")]
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// شناسه مکان (اختیاری)
    /// </summary>
    public Guid? BinId { get; set; }

    /// <summary>
    /// مقدار موجودی
    /// </summary>
    [Required(ErrorMessage = "مقدار موجودی الزامی است")]
    [Range(0, double.MaxValue, ErrorMessage = "مقدار موجودی نمی‌تواند منفی باشد")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// مقدار رزرو شده
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "مقدار رزرو شده نمی‌تواند منفی باشد")]
    public decimal ReservedQuantity { get; set; } = 0;

    /// <summary>
    /// حداقل موجودی
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "حداقل موجودی نمی‌تواند منفی باشد")]
    public decimal MinQuantity { get; set; } = 0;

    /// <summary>
    /// حداکثر موجودی
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "حداکثر موجودی نمی‌تواند منفی باشد")]
    public decimal MaxQuantity { get; set; } = 0;

    /// <summary>
    /// قیمت واحد
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "قیمت واحد نمی‌تواند منفی باشد")]
    public decimal UnitPrice { get; set; } = 0;

    /// <summary>
    /// تاریخ انقضا (اختیاری)
    /// </summary>
    public DateTime? ExpiryDate { get; set; }

    /// <summary>
    /// شماره سریال/بچ (اختیاری)
    /// </summary>
    [StringLength(100, ErrorMessage = "شماره سریال/بچ نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string SerialNumber { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    [StringLength(500, ErrorMessage = "توضیحات نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string Description { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
