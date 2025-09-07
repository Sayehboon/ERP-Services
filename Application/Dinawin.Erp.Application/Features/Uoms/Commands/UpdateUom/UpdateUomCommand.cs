using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Uoms.Commands.UpdateUom;

/// <summary>
/// دستور به‌روزرسانی واحد اندازه‌گیری
/// </summary>
public sealed class UpdateUomCommand : IRequest<Guid>
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
    /// نوع واحد اندازه‌گیری
    /// </summary>
    [Required(ErrorMessage = "نوع واحد اندازه‌گیری الزامی است")]
    [StringLength(50, ErrorMessage = "نوع واحد اندازه‌گیری نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string UomType { get; set; } = "Count";

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
