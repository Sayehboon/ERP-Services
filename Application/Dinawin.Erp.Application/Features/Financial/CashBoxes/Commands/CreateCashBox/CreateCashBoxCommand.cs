using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Commands.CreateCashBox;

/// <summary>
/// دستور ایجاد صندوق نقدی جدید
/// </summary>
public class CreateCashBoxCommand : IRequest<Guid>
{
    /// <summary>
    /// نام صندوق
    /// </summary>
    [Required(ErrorMessage = "نام صندوق الزامی است")]
    [StringLength(100, ErrorMessage = "نام صندوق نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد صندوق
    /// </summary>
    [Required(ErrorMessage = "کد صندوق الزامی است")]
    [StringLength(50, ErrorMessage = "کد صندوق نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// مکان صندوق
    /// </summary>
    [StringLength(200, ErrorMessage = "مکان صندوق نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string? Location { get; set; }

    /// <summary>
    /// شناسه مسئول صندوق
    /// </summary>
    public Guid? ResponsiblePersonId { get; set; }

    /// <summary>
    /// موجودی اولیه
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "موجودی اولیه باید مثبت باشد")]
    public decimal InitialBalance { get; set; } = 0;

    /// <summary>
    /// ارز
    /// </summary>
    [Required(ErrorMessage = "ارز الزامی است")]
    [StringLength(3, ErrorMessage = "ارز باید 3 کاراکتر باشد")]
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;
}
