using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Financial.BankAccounts.Commands.UpdateBankAccount;

/// <summary>
/// دستور به‌روزرسانی حساب بانکی
/// </summary>
public sealed class UpdateBankAccountCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه حساب بانکی
    /// </summary>
    [Required(ErrorMessage = "شناسه حساب بانکی الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام حساب
    /// </summary>
    [Required(ErrorMessage = "نام حساب الزامی است")]
    [StringLength(200, ErrorMessage = "نام حساب نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string AccountName { get; set; } = string.Empty;

    /// <summary>
    /// شماره حساب
    /// </summary>
    [Required(ErrorMessage = "شماره حساب الزامی است")]
    [StringLength(50, ErrorMessage = "شماره حساب نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string AccountNumber { get; set; } = string.Empty;

    /// <summary>
    /// نام بانک
    /// </summary>
    [Required(ErrorMessage = "نام بانک الزامی است")]
    [StringLength(100, ErrorMessage = "نام بانک نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string BankName { get; set; } = string.Empty;

    /// <summary>
    /// کد بانک
    /// </summary>
    [StringLength(20, ErrorMessage = "کد بانک نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string BankCode { get; set; }

    /// <summary>
    /// نوع حساب
    /// </summary>
    [Required(ErrorMessage = "نوع حساب الزامی است")]
    [StringLength(50, ErrorMessage = "نوع حساب نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string AccountType { get; set; } = string.Empty;

    /// <summary>
    /// ارز حساب
    /// </summary>
    [Required(ErrorMessage = "ارز حساب الزامی است")]
    [StringLength(10, ErrorMessage = "کد ارز نمی‌تواند بیش از 10 کاراکتر باشد")]
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// موجودی اولیه
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "موجودی اولیه نمی‌تواند منفی باشد")]
    public decimal InitialBalance { get; set; } = 0;

    /// <summary>
    /// موجودی فعلی
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "موجودی فعلی نمی‌تواند منفی باشد")]
    public decimal CurrentBalance { get; set; } = 0;

    /// <summary>
    /// آدرس شعبه
    /// </summary>
    [StringLength(500, ErrorMessage = "آدرس شعبه نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string BranchAddress { get; set; }

    /// <summary>
    /// شماره تلفن شعبه
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره تلفن نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string BranchPhone { get; set; }

    /// <summary>
    /// نام صاحب حساب
    /// </summary>
    [StringLength(200, ErrorMessage = "نام صاحب حساب نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string AccountHolderName { get; set; }

    /// <summary>
    /// آیا حساب فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// توضیحات
    /// </summary>
    [StringLength(500, ErrorMessage = "توضیحات نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string Description { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
