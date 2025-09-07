using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Inventory.Bins.Commands.UpdateBin;

/// <summary>
/// دستور به‌روزرسانی مکان
/// </summary>
public sealed class UpdateBinCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه مکان
    /// </summary>
    [Required(ErrorMessage = "شناسه مکان الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام مکان
    /// </summary>
    [Required(ErrorMessage = "نام مکان الزامی است")]
    [StringLength(100, ErrorMessage = "نام مکان نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد مکان
    /// </summary>
    [Required(ErrorMessage = "کد مکان الزامی است")]
    [StringLength(50, ErrorMessage = "کد مکان نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// شناسه انبار
    /// </summary>
    [Required(ErrorMessage = "شناسه انبار الزامی است")]
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// نوع مکان
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع مکان نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? BinType { get; set; }

    /// <summary>
    /// ظرفیت مکان
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "ظرفیت مکان نمی‌تواند منفی باشد")]
    public decimal? Capacity { get; set; }

    /// <summary>
    /// واحد ظرفیت
    /// </summary>
    [StringLength(20, ErrorMessage = "واحد ظرفیت نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? CapacityUnit { get; set; }

    /// <summary>
    /// عرض مکان (متر)
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "عرض مکان نمی‌تواند منفی باشد")]
    public decimal? Width { get; set; }

    /// <summary>
    /// طول مکان (متر)
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "طول مکان نمی‌تواند منفی باشد")]
    public decimal? Length { get; set; }

    /// <summary>
    /// ارتفاع مکان (متر)
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "ارتفاع مکان نمی‌تواند منفی باشد")]
    public decimal? Height { get; set; }

    /// <summary>
    /// موقعیت مکان در انبار
    /// </summary>
    [StringLength(100, ErrorMessage = "موقعیت مکان نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? Location { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    [StringLength(500, ErrorMessage = "توضیحات نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}