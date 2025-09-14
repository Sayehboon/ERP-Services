using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Commands.CreateCashBox;

/// <summary>
/// دستور ایجاد صندوق نقدی جدید
/// </summary>
public class CreateCashBoxCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// </summary>
    [Required(ErrorMessage = "شناسه کسب‌وکار الزامی است")]
    public Guid BusinessId { get; set; }

    /// <summary>
    /// نام صندوق
    /// </summary>
    [Required(ErrorMessage = "نام صندوق الزامی است")]
    [StringLength(200, ErrorMessage = "نام صندوق نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// مکان صندوق
    /// </summary>
    [StringLength(200, ErrorMessage = "مکان صندوق نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Location { get; set; }

    /// <summary>
    /// شناسه حساب کنترل
    /// </summary>
    public Guid? ControlAccountId { get; set; }
}
