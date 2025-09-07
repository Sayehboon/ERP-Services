using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Commands.UpdateChartOfAccount;

/// <summary>
/// دستور به‌روزرسانی حساب کل
/// </summary>
public sealed class UpdateChartOfAccountCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه حساب کل
    /// </summary>
    [Required(ErrorMessage = "شناسه حساب کل الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// کد حساب
    /// </summary>
    [Required(ErrorMessage = "کد حساب الزامی است")]
    [StringLength(20, ErrorMessage = "کد حساب نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string AccountCode { get; set; } = string.Empty;

    /// <summary>
    /// نام حساب
    /// </summary>
    [Required(ErrorMessage = "نام حساب الزامی است")]
    [StringLength(200, ErrorMessage = "نام حساب نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string AccountName { get; set; } = string.Empty;

    /// <summary>
    /// شناسه حساب والد
    /// </summary>
    public Guid? ParentAccountId { get; set; }

    /// <summary>
    /// نوع حساب
    /// </summary>
    [Required(ErrorMessage = "نوع حساب الزامی است")]
    [StringLength(50, ErrorMessage = "نوع حساب نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string AccountType { get; set; } = string.Empty;

    /// <summary>
    /// دسته حساب
    /// </summary>
    [StringLength(50, ErrorMessage = "دسته حساب نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? AccountCategory { get; set; }

    /// <summary>
    /// سطح حساب
    /// </summary>
    [Range(1, 10, ErrorMessage = "سطح حساب باید بین 1 تا 10 باشد")]
    public int Level { get; set; } = 1;

    /// <summary>
    /// آیا حساب فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// آیا حساب قابل ویرایش است
    /// </summary>
    public bool IsEditable { get; set; } = true;

    /// <summary>
    /// آیا حساب قابل حذف است
    /// </summary>
    public bool IsDeletable { get; set; } = true;

    /// <summary>
    /// توضیحات
    /// </summary>
    [StringLength(500, ErrorMessage = "توضیحات نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
