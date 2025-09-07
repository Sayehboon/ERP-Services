using MediatR;

namespace Dinawin.Erp.Application.Features.CRM.Activities.Commands.DeleteActivity;

/// <summary>
/// دستور حذف فعالیت
/// </summary>
public class DeleteActivityCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه فعالیت
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف‌کننده
    /// </summary>
    public Guid DeletedByUserId { get; set; }
}
