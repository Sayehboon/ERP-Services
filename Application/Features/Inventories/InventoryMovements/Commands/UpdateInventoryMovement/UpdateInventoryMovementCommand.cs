using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Inventories.InventoryMovements.Commands.UpdateInventoryMovement;

/// <summary>
/// دستور به‌روزرسانی حرکت موجودی
/// </summary>
public sealed class UpdateInventoryMovementCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه حرکت موجودی
    /// </summary>
    [Required(ErrorMessage = "شناسه حرکت موجودی الزامی است")]
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
    /// نوع حرکت
    /// </summary>
    [Required(ErrorMessage = "نوع حرکت الزامی است")]
    [StringLength(50, ErrorMessage = "نوع حرکت نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string MovementType { get; set; } = string.Empty;

    /// <summary>
    /// مقدار حرکت
    /// </summary>
    [Required(ErrorMessage = "مقدار حرکت الزامی است")]
    [Range(0.01, double.MaxValue, ErrorMessage = "مقدار حرکت باید بزرگتر از صفر باشد")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// واحد اندازه‌گیری
    /// </summary>
    [Required(ErrorMessage = "واحد اندازه‌گیری الزامی است")]
    [StringLength(20, ErrorMessage = "واحد اندازه‌گیری نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Unit { get; set; } = string.Empty;

    /// <summary>
    /// قیمت واحد
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "قیمت واحد نمی‌تواند منفی باشد")]
    public decimal? UnitPrice { get; set; }

    /// <summary>
    /// قیمت کل
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "قیمت کل نمی‌تواند منفی باشد")]
    public decimal? TotalPrice { get; set; }

    /// <summary>
    /// تاریخ حرکت
    /// </summary>
    [Required(ErrorMessage = "تاریخ حرکت الزامی است")]
    public DateTime MovementDate { get; set; }

    /// <summary>
    /// شماره سند مرجع
    /// </summary>
    [StringLength(100, ErrorMessage = "شماره سند مرجع نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string ReferenceNumber { get; set; }

    /// <summary>
    /// نوع سند مرجع
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع سند مرجع نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string ReferenceType { get; set; }

    /// <summary>
    /// شناسه سند مرجع
    /// </summary>
    public Guid? ReferenceId { get; set; }

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
