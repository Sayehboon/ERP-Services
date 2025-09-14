using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Financial.BankAccounts.Commands.CreateBankAccount;

/// <summary>
/// دستور ایجاد حساب بانکی جدید
/// </summary>
public sealed class CreateBankAccountCommand : IRequest<Guid>
{
    /// <summary>
    /// نام بانک
    /// </summary>
    [Required(ErrorMessage = "نام بانک الزامی است")]
    [StringLength(100, ErrorMessage = "نام بانک نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string BankName { get; set; } = string.Empty;

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
    /// شاخه بانک
    /// </summary>
    [StringLength(100, ErrorMessage = "نام شاخه نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string BranchName { get; set; }

    /// <summary>
    /// کد شاخه
    /// </summary>
    [StringLength(20, ErrorMessage = "کد شاخه نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string BranchCode { get; set; }

    /// <summary>
    /// آدرس شاخه
    /// </summary>
    [StringLength(500, ErrorMessage = "آدرس شاخه نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string BranchAddress { get; set; }

    /// <summary>
    /// شماره تلفن شاخه
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره تلفن نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string BranchPhone { get; set; }

    /// <summary>
    /// شماره کارت
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره کارت نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string CardNumber { get; set; }

    /// <summary>
    /// شماره شبا
    /// </summary>
    [StringLength(26, ErrorMessage = "شماره شبا نمی‌تواند بیش از 26 کاراکتر باشد")]
    public string Iban { get; set; }

    /// <summary>
    /// آیا حساب فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// توضیحات
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string Notes { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }
}