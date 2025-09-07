using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Financial.BankAccounts.Commands.DeleteBankAccount;

/// <summary>
/// دستور حذف حساب بانکی
/// </summary>
public sealed class DeleteBankAccountCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه حساب بانکی
    /// </summary>
    [Required(ErrorMessage = "شناسه حساب بانکی الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
