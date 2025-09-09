using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Inventories.Warehouses.Commands.UpdateWarehouse;

/// <summary>
/// دستور به‌روزرسانی انبار
/// </summary>
public sealed class UpdateWarehouseCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه انبار
    /// </summary>
    [Required(ErrorMessage = "شناسه انبار الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام انبار
    /// </summary>
    [Required(ErrorMessage = "نام انبار الزامی است")]
    [StringLength(200, ErrorMessage = "نام انبار نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد انبار
    /// </summary>
    [Required(ErrorMessage = "کد انبار الزامی است")]
    [StringLength(50, ErrorMessage = "کد انبار نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// آدرس انبار
    /// </summary>
    [StringLength(500, ErrorMessage = "آدرس انبار نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Address { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره تلفن نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// ایمیل
    /// </summary>
    [EmailAddress(ErrorMessage = "فرمت ایمیل معتبر نیست")]
    [StringLength(100, ErrorMessage = "ایمیل نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? Email { get; set; }

    /// <summary>
    /// نام مسئول انبار
    /// </summary>
    [StringLength(100, ErrorMessage = "نام مسئول انبار نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? ManagerName { get; set; }

    /// <summary>
    /// ظرفیت انبار
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "ظرفیت انبار نمی‌تواند منفی باشد")]
    public decimal? Capacity { get; set; }

    /// <summary>
    /// واحد ظرفیت
    /// </summary>
    [StringLength(20, ErrorMessage = "واحد ظرفیت نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? CapacityUnit { get; set; }

    /// <summary>
    /// نوع انبار
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع انبار نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? WarehouseType { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات نمی‌تواند بیش از 1000 کاراکتر باشد")]
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