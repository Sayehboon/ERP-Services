using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Uoms.Commands.DeleteUom;

/// <summary>
/// دستور حذف واحد اندازه‌گیری
/// </summary>
public sealed class DeleteUomCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه واحد اندازه‌گیری
    /// </summary>
    [Required(ErrorMessage = "شناسه واحد اندازه‌گیری الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف‌کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }

    /// <summary>
    /// دلیل حذف
    /// </summary>
    [StringLength(500)]
    public string? DeleteReason { get; set; }
}
