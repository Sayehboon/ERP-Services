namespace Dinawin.Erp.Application.Features.Financial.BankAccounts.Queries.GetAllBankAccounts;

/// <summary>
/// مدل انتقال داده حساب بانکی
/// </summary>
public sealed class BankAccountDto
{
    /// <summary>
    /// شناسه حساب بانکی
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام حساب
    /// </summary>
    public string AccountName { get; set; } = string.Empty;

    /// <summary>
    /// شماره حساب
    /// </summary>
    public string AccountNumber { get; set; } = string.Empty;

    /// <summary>
    /// نام بانک
    /// </summary>
    public string BankName { get; set; } = string.Empty;

    /// <summary>
    /// کد بانک
    /// </summary>
    public string? BankCode { get; set; }

    /// <summary>
    /// نوع حساب
    /// </summary>
    public string AccountType { get; set; } = string.Empty;

    /// <summary>
    /// ارز حساب
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// موجودی اولیه
    /// </summary>
    public decimal InitialBalance { get; set; }

    /// <summary>
    /// موجودی فعلی
    /// </summary>
    public decimal CurrentBalance { get; set; }

    /// <summary>
    /// آدرس شعبه
    /// </summary>
    public string? BranchAddress { get; set; }

    /// <summary>
    /// شماره تلفن شعبه
    /// </summary>
    public string? BranchPhone { get; set; }

    /// <summary>
    /// نام صاحب حساب
    /// </summary>
    public string? AccountHolderName { get; set; }

    /// <summary>
    /// آیا حساب فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
