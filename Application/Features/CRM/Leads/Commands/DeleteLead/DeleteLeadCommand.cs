using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.CRM.Leads.Commands.DeleteLead;

/// <summary>
/// دستور حذف لید
/// </summary>
public sealed class DeleteLeadCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه لید
    /// </summary>
    [Required(ErrorMessage = "شناسه لید الزامی است")]
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
