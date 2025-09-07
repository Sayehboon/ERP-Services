namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetAllChartOfAccounts;

/// <summary>
/// مدل انتقال داده حساب کل
/// </summary>
public sealed class ChartOfAccountDto
{
    /// <summary>
    /// شناسه حساب کل
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// کد حساب
    /// </summary>
    public string AccountCode { get; set; } = string.Empty;

    /// <summary>
    /// نام حساب
    /// </summary>
    public string AccountName { get; set; } = string.Empty;

    /// <summary>
    /// شناسه حساب والد
    /// </summary>
    public Guid? ParentAccountId { get; set; }

    /// <summary>
    /// نام حساب والد
    /// </summary>
    public string? ParentAccountName { get; set; }

    /// <summary>
    /// نوع حساب
    /// </summary>
    public string AccountType { get; set; } = string.Empty;

    /// <summary>
    /// دسته حساب
    /// </summary>
    public string? AccountCategory { get; set; }

    /// <summary>
    /// سطح حساب
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// آیا حساب فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// آیا حساب قابل ویرایش است
    /// </summary>
    public bool IsEditable { get; set; }

    /// <summary>
    /// آیا حساب قابل حذف است
    /// </summary>
    public bool IsDeletable { get; set; }

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

    /// <summary>
    /// تعداد حساب‌های فرزند
    /// </summary>
    public int ChildrenCount { get; set; }
}
