using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Trims.Commands.DeleteTrim;

/// <summary>
/// دستور حذف تریم
/// </summary>
public sealed class DeleteTrimCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه تریم
    /// </summary>
    [Required(ErrorMessage = "شناسه تریم الزامی است")]
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
