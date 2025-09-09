using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// موجودی افتتاحیه
/// Opening Balance
/// </summary>
public class AccOpeningBalance : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه حساب
    /// Account ID
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// شناسه دوره مالی
    /// Fiscal Period ID
    /// </summary>
    public Guid FiscalPeriodId { get; set; }

    /// <summary>
    /// مانده بدهکار
    /// Debit Balance
    /// </summary>
    public decimal DebitBalance { get; set; } = 0;

    /// <summary>
    /// مانده بستانکار
    /// Credit Balance
    /// </summary>
    public decimal CreditBalance { get; set; } = 0;

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// Exchange Rate
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// مانده بدهکار به ارز اصلی
    /// Debit Balance in Base Currency
    /// </summary>
    public decimal DebitBalanceBase { get; set; } = 0;

    /// <summary>
    /// مانده بستانکار به ارز اصلی
    /// Credit Balance in Base Currency
    /// </summary>
    public decimal CreditBalanceBase { get; set; } = 0;

    /// <summary>
    /// تاریخ ثبت
    /// Registration Date
    /// </summary>
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// شناسه کاربر ثبت کننده
    /// Registered By User ID
    /// </summary>
    public Guid RegisteredByUserId { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// آیا تایید شده است
    /// Is Approved
    /// </summary>
    public bool IsApproved { get; set; } = false;

    /// <summary>
    /// تاریخ تایید
    /// Approval Date
    /// </summary>
    public DateTime? ApprovalDate { get; set; }

    /// <summary>
    /// شناسه کاربر تایید کننده
    /// Approved By User ID
    /// </summary>
    public Guid? ApprovedByUserId { get; set; }

    // Navigation Properties
    /// <summary>
    /// حساب
    /// Account
    /// </summary>
    public virtual Account? Account { get; set; }

    /// <summary>
    /// دوره مالی
    /// Fiscal Period
    /// </summary>
    public virtual AccFiscalPeriod? FiscalPeriod { get; set; }

    /// <summary>
    /// کاربر ثبت کننده
    /// Registered By User
    /// </summary>
    public virtual User? RegisteredByUser { get; set; }

    /// <summary>
    /// کاربر تایید کننده
    /// Approved By User
    /// </summary>
    public virtual User? ApprovedByUser { get; set; }
}
