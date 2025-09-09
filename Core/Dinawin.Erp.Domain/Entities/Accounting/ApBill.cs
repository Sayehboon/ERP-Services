using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// فاکتور حساب‌های پرداختنی
/// Accounts Payable Bill
/// </summary>
public class ApBill : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// شناسه تامین‌کننده
    /// Vendor ID
    /// </summary>
    public Guid VendorId { get; set; }

    /// <summary>
    /// شماره فاکتور
    /// Bill number
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// تاریخ فاکتور
    /// Bill date
    /// </summary>
    public DateTime BillDate { get; set; }

    /// <summary>
    /// تاریخ سررسید
    /// Due date
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// Exchange rate
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// مبلغ خالص
    /// Subtotal
    /// </summary>
    public decimal Subtotal { get; set; } = 0;

    /// <summary>
    /// مبلغ مالیات
    /// Tax amount
    /// </summary>
    public decimal TaxAmount { get; set; } = 0;

    /// <summary>
    /// مبلغ تخفیف
    /// Discount amount
    /// </summary>
    public decimal DiscountAmount { get; set; } = 0;

    /// <summary>
    /// مبلغ کل
    /// Total amount
    /// </summary>
    public decimal Total { get; set; } = 0;

    /// <summary>
    /// وضعیت فاکتور
    /// Bill status
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// وضعیت تایید
    /// Approval status
    /// </summary>
    public string ApprovalStatus { get; set; } = "draft";

    /// <summary>
    /// شناسه دوره مالی
    /// Fiscal period ID
    /// </summary>
    public Guid? FiscalPeriodId { get; set; }

    /// <summary>
    /// شناسه سال مالی
    /// Fiscal year ID
    /// </summary>
    public Guid? FiscalYearId { get; set; }

    /// <summary>
    /// پست شده؟
    /// Is posted?
    /// </summary>
    public bool Posted { get; set; } = false;

    /// <summary>
    /// تاریخ پست
    /// Posted at
    /// </summary>
    public DateTime? PostedAt { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// تامین‌کننده مرتبط
    /// Related vendor
    /// </summary>
    public ApVendor Vendor { get; set; } = null!;

    /// <summary>
    /// خطوط فاکتور
    /// Bill lines
    /// </summary>
    public ICollection<ApBillLine> Lines { get; set; } = new List<ApBillLine>();

    /// <summary>
    /// تسویه‌های فاکتور
    /// Bill settlements
    /// </summary>
    public ICollection<ApSettlement> Settlements { get; set; } = new List<ApSettlement>();

    /// <summary>
    /// دوره مالی
    /// Fiscal period
    /// </summary>
    public FiscalPeriod? FiscalPeriod { get; set; }

    /// <summary>
    /// سال مالی
    /// Fiscal year
    /// </summary>
    public FiscalYear? FiscalYear { get; set; }
}
