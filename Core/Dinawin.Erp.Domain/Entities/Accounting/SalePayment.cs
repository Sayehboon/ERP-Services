using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// پرداخت فروش
/// </summary>
public class SalePayment : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه سفارش فروش
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// شناسه صندوق نقدی
    /// </summary>
    public Guid? CashBoxId { get; set; }

    /// <summary>
    /// شناسه حساب بانکی
    /// </summary>
    public Guid? BankAccountId { get; set; }

    /// <summary>
    /// تاریخ پرداخت
    /// </summary>
    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// مبلغ پرداخت
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// مبلغ به ارز اصلی
    /// </summary>
    public decimal? AmountInBaseCurrency { get; set; }

    /// <summary>
    /// روش پرداخت
    /// </summary>
    public string PaymentMethod { get; set; } = string.Empty;

    /// <summary>
    /// شماره مرجع
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// شماره چک (در صورت پرداخت با چک)
    /// </summary>
    public string? CheckNumber { get; set; }

    /// <summary>
    /// تاریخ سررسید چک
    /// </summary>
    public DateTime? CheckDueDate { get; set; }

    /// <summary>
    /// وضعیت پرداخت
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// شناسه کاربر تاییدکننده
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// تاریخ تایید
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// سفارش فروش مرتبط
    /// </summary>
    public Sales.SalesOrder Sale { get; set; } = null!;

    /// <summary>
    /// صندوق نقدی مرتبط
    /// </summary>
    public Treasury.CashBox? CashBox { get; set; }

    /// <summary>
    /// حساب بانکی مرتبط
    /// </summary>
    public Treasury.BankAccount? BankAccount { get; set; }

    /// <summary>
    /// کاربر ایجادکننده
    /// </summary>
    public Users.User? CreatedByUser { get; set; }

    /// <summary>
    /// کاربر تاییدکننده
    /// </summary>
    public Users.User? ApprovedByUser { get; set; }
}
