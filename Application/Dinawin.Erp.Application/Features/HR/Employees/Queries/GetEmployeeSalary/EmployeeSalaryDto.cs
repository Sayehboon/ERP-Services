namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeSalary;

/// <summary>
/// DTO حقوق کارمند
/// </summary>
public class EmployeeSalaryDto
{
    /// <summary>
    /// شناسه حقوق
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کارمند
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// نام کارمند
    /// </summary>
    public string EmployeeName { get; set; } = string.Empty;

    /// <summary>
    /// کد کارمند
    /// </summary>
    public string EmployeeCode { get; set; } = string.Empty;

    /// <summary>
    /// سال
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// ماه
    /// </summary>
    public int Month { get; set; }

    /// <summary>
    /// نام ماه
    /// </summary>
    public string MonthName { get; set; } = string.Empty;

    /// <summary>
    /// حقوق پایه
    /// </summary>
    public decimal BaseSalary { get; set; }

    /// <summary>
    /// اضافه کار
    /// </summary>
    public decimal OvertimePay { get; set; }

    /// <summary>
    /// پاداش
    /// </summary>
    public decimal Bonus { get; set; }

    /// <summary>
    /// مزایا
    /// </summary>
    public decimal Allowances { get; set; }

    /// <summary>
    /// کسر بیمه
    /// </summary>
    public decimal InsuranceDeduction { get; set; }

    /// <summary>
    /// کسر مالیات
    /// </summary>
    public decimal TaxDeduction { get; set; }

    /// <summary>
    /// کسر سایر موارد
    /// </summary>
    public decimal OtherDeductions { get; set; }

    /// <summary>
    /// مجموع کسرها
    /// </summary>
    public decimal TotalDeductions => InsuranceDeduction + TaxDeduction + OtherDeductions;

    /// <summary>
    /// مجموع اضافات
    /// </summary>
    public decimal TotalAdditions => OvertimePay + Bonus + Allowances;

    /// <summary>
    /// حقوق خالص
    /// </summary>
    public decimal NetSalary => BaseSalary + TotalAdditions - TotalDeductions;

    /// <summary>
    /// حقوق ناخالص
    /// </summary>
    public decimal GrossSalary => BaseSalary + TotalAdditions;

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// حقوق به ارز اصلی
    /// </summary>
    public decimal? SalaryInBaseCurrency { get; set; }

    /// <summary>
    /// وضعیت پرداخت
    /// </summary>
    public string PaymentStatus { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت پرداخت به فارسی
    /// </summary>
    public string PaymentStatusPersian { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ پرداخت
    /// </summary>
    public DateTime? PaymentDate { get; set; }

    /// <summary>
    /// روش پرداخت
    /// </summary>
    public string PaymentMethod { get; set; } = string.Empty;

    /// <summary>
    /// شماره چک
    /// </summary>
    public string? CheckNumber { get; set; }

    /// <summary>
    /// شماره مرجع
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// نام کاربر ایجادکننده
    /// </summary>
    public string? CreatedByName { get; set; }

    /// <summary>
    /// شناسه کاربر تاییدکننده
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// نام کاربر تاییدکننده
    /// </summary>
    public string? ApprovedByName { get; set; }

    /// <summary>
    /// تاریخ تایید
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// جزئیات حقوق
    /// </summary>
    public List<SalaryDetailDto> Details { get; set; } = new();

    /// <summary>
    /// شناسه بخش
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// نام بخش
    /// </summary>
    public string? DepartmentName { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string? CompanyName { get; set; }
}

/// <summary>
/// DTO جزئیات حقوق
/// </summary>
public class SalaryDetailDto
{
    /// <summary>
    /// شناسه جزئیات
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نوع جزئیات
    /// </summary>
    public string DetailType { get; set; } = string.Empty;

    /// <summary>
    /// نوع جزئیات به فارسی
    /// </summary>
    public string DetailTypePersian { get; set; } = string.Empty;

    /// <summary>
    /// دسته‌بندی
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// دسته‌بندی به فارسی
    /// </summary>
    public string CategoryPersian { get; set; } = string.Empty;

    /// <summary>
    /// مبلغ
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// درصد
    /// </summary>
    public decimal? Percentage { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// آیا اضافه است
    /// </summary>
    public bool IsAddition { get; set; }

    /// <summary>
    /// آیا کسر است
    /// </summary>
    public bool IsDeduction => !IsAddition;
}
