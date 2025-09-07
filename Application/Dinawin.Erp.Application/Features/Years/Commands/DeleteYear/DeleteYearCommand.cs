using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Years.Commands.DeleteYear;

/// <summary>
/// دستور حذف سال
/// </summary>
public sealed class DeleteYearCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه سال
    /// </summary>
    [Required(ErrorMessage = "شناسه سال الزامی است")]
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
