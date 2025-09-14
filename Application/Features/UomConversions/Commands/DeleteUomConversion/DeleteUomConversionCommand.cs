using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.UomConversions.Commands.DeleteUomConversion;

/// <summary>
/// دستور حذف تبدیل واحد اندازه‌گیری
/// </summary>
public sealed class DeleteUomConversionCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه تبدیل واحد اندازه‌گیری
    /// </summary>
    [Required(ErrorMessage = "شناسه تبدیل واحد اندازه‌گیری الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف‌کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }

    /// <summary>
    /// دلیل حذف
    /// </summary>
    [StringLength(500)]
    public string DeleteReason { get; set; }
}
