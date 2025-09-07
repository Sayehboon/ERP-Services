using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.UomConversions.Commands.CreateUomConversion;

/// <summary>
/// دستور ایجاد تبدیل واحد اندازه‌گیری
/// </summary>
public sealed class CreateUomConversionCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه واحد اندازه‌گیری مبدا
    /// </summary>
    [Required(ErrorMessage = "شناسه واحد اندازه‌گیری مبدا الزامی است")]
    public Guid FromUomId { get; set; }

    /// <summary>
    /// شناسه واحد اندازه‌گیری مقصد
    /// </summary>
    [Required(ErrorMessage = "شناسه واحد اندازه‌گیری مقصد الزامی است")]
    public Guid ToUomId { get; set; }

    /// <summary>
    /// ضریب تبدیل
    /// </summary>
    [Required(ErrorMessage = "ضریب تبدیل الزامی است")]
    [Range(0.0001, double.MaxValue, ErrorMessage = "ضریب تبدیل باید مثبت باشد")]
    public decimal ConversionFactor { get; set; }

    /// <summary>
    /// نام تبدیل
    /// </summary>
    [StringLength(200, ErrorMessage = "نام تبدیل نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string? Name { get; set; }

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
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }
}
