using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Models.Commands.DeleteModel;

/// <summary>
/// دستور حذف مدل
/// </summary>
public sealed class DeleteModelCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه مدل
    /// </summary>
    [Required(ErrorMessage = "شناسه مدل الزامی است")]
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
