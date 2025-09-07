using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Commands.DeleteChartOfAccount;

/// <summary>
/// دستور حذف حساب کل
/// </summary>
public sealed class DeleteChartOfAccountCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه حساب کل
    /// </summary>
    [Required(ErrorMessage = "شناسه حساب کل الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
