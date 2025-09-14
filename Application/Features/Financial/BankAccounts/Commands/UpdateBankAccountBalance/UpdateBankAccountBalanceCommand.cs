using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Financial.BankAccounts.Commands.UpdateBankAccountBalance;

/// <summary>
/// دستور به‌روزرسانی موجودی حساب بانکی
/// </summary>
public sealed class UpdateBankAccountBalanceCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه حساب بانکی
    /// </summary>
    [Required(ErrorMessage = "شناسه حساب بانکی الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// موجودی جدید
    /// </summary>
    [Required(ErrorMessage = "موجودی جدید الزامی است")]
    [Range(0, double.MaxValue, ErrorMessage = "موجودی نمی‌تواند منفی باشد")]
    public decimal NewBalance { get; set; }

    /// <summary>
    /// نوع تراکنش
    /// </summary>
    [Required(ErrorMessage = "نوع تراکنش الزامی است")]
    [StringLength(50, ErrorMessage = "نوع تراکنش نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string TransactionType { get; set; } = string.Empty;

    /// <summary>
    /// مبلغ تراکنش
    /// </summary>
    [Required(ErrorMessage = "مبلغ تراکنش الزامی است")]
    [Range(0, double.MaxValue, ErrorMessage = "مبلغ تراکنش نمی‌تواند منفی باشد")]
    public decimal TransactionAmount { get; set; }

    /// <summary>
    /// توضیحات تراکنش
    /// </summary>
    [StringLength(500, ErrorMessage = "توضیحات تراکنش نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string TransactionDescription { get; set; }

    /// <summary>
    /// شناسه مرجع تراکنش
    /// </summary>
    public Guid? ReferenceId { get; set; }

    /// <summary>
    /// نوع مرجع تراکنش
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع مرجع تراکنش نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string ReferenceType { get; set; }

    /// <summary>
    /// شناسه کاربر انجام دهنده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
