using MediatR;
using Dinawin.Erp.Domain.Enums;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Commands.CreateAccount;

/// <summary>
/// دستور ایجاد حساب جدید
/// </summary>
public class CreateAccountCommand : IRequest<Guid>
{
    /// <summary>
    /// کد حساب
    /// </summary>
    public string AccountCode { get; set; } = string.Empty;

    /// <summary>
    /// نام حساب
    /// </summary>
    public string AccountName { get; set; } = string.Empty;

    /// <summary>
    /// نام انگلیسی حساب
    /// </summary>
    public string AccountNameEn { get; set; }

    /// <summary>
    /// شناسه حساب والد
    /// </summary>
    public Guid? ParentAccountId { get; set; }

    /// <summary>
    /// نوع حساب
    /// </summary>
    public AccountTypeEnum AccountType { get; set; }

    /// <summary>
    /// سطح حساب
    /// </summary>
    public int Level { get; set; } = 1;

    /// <summary>
    /// تراز طبیعی
    /// </summary>
    public NormalBalanceEnum NormalBalance { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// قابل ویرایش
    /// </summary>
    public bool IsEditable { get; set; } = true;

    /// <summary>
    /// قابل حذف
    /// </summary>
    public bool IsDeletable { get; set; } = true;

    /// <summary>
    /// ترتیب نمایش
    /// </summary>
    public int DisplayOrder { get; set; } = 0;

    /// <summary>
    /// توضیحات
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// </summary>
    public Guid CreatedByUserId { get; set; }
}
