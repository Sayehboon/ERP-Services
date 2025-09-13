using MediatR;
using System.ComponentModel.DataAnnotations;
using Dinawin.Erp.Application.Features.Financial.BankAccounts.DTOs;

namespace Dinawin.Erp.Application.Features.Financial.BankAccounts.Queries.GetBankAccountById;

/// <summary>
/// پرس‌وجو دریافت حساب بانکی بر اساس شناسه
/// </summary>
public sealed class GetBankAccountByIdQuery : IRequest<BankAccountDto?>
{
    /// <summary>
    /// شناسه حساب بانکی
    /// </summary>
    [Required(ErrorMessage = "شناسه حساب بانکی الزامی است")]
    public Guid Id { get; set; }
}
