using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Units.Commands.UpdateUnit;

/// <summary>
/// دستور به‌روزرسانی واحد اندازه‌گیری
/// </summary>
public sealed class UpdateUnitCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه واحد اندازه‌گیری
    /// </summary>
    [Required(ErrorMessage = "شناسه واحد اندازه‌گیری الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام واحد اندازه‌گیری
    /// </summary>
    [Required(ErrorMessage = "نام واحد اندازه‌گیری الزامی است")]
    [StringLength(100, ErrorMessage = "نام واحد اندازه‌گیری نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد واحد اندازه‌گیری
    /// </summary>
    [Required(ErrorMessage = "کد واحد اندازه‌گیری الزامی است")]
    [StringLength(20, ErrorMessage = "کد واحد اندازه‌گیری نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نماد واحد اندازه‌گیری
    /// </summary>
    [StringLength(10, ErrorMessage = "نماد واحد اندازه‌گیری نمی‌تواند بیش از 10 کاراکتر باشد")]
    public string? Symbol { get; set; }

    /// <summary>
    /// توضیحات واحد اندازه‌گیری
    /// </summary>
    [StringLength(500, ErrorMessage = "توضیحات واحد اندازه‌گیری نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// نوع واحد اندازه‌گیری
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع واحد اندازه‌گیری نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? UnitType { get; set; }

    /// <summary>
    /// ضریب تبدیل به واحد پایه
    /// </summary>
    [Range(0.0001, double.MaxValue, ErrorMessage = "ضریب تبدیل باید مثبت باشد")]
    public decimal ConversionFactor { get; set; } = 1;

    /// <summary>
    /// شناسه واحد پایه
    /// </summary>
    public Guid? BaseUnitId { get; set; }

    /// <summary>
    /// وضعیت فعال بودن واحد اندازه‌گیری
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// ترتیب نمایش
    /// </summary>
    [Range(0, int.MaxValue, ErrorMessage = "ترتیب نمایش باید عددی مثبت باشد")]
    public int SortOrder { get; set; } = 0;

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
