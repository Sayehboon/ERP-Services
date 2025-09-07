using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.CRM.Opportunities.Commands.DeleteOpportunity;

/// <summary>
/// دستور حذف فرصت
/// </summary>
public sealed class DeleteOpportunityCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه فرصت
    /// </summary>
    [Required(ErrorMessage = "شناسه فرصت الزامی است")]
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
