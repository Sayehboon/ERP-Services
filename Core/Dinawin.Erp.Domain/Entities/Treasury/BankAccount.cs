namespace Dinawin.Erp.Domain.Entities.Treasury;

using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// موجودیت حساب بانکی
/// Bank account entity
/// </summary>
public class BankAccount : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام حساب بانکی
    /// Bank account name
    /// </summary>
    public required string AccountName { get; set; }

    /// <summary>
    /// شماره IBAN
    /// IBAN number
    /// </summary>
    public string? Iban { get; set; }

    /// <summary>
    /// ارز حساب
    /// Account currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// شناسه حساب کنترل
    /// Control account ID
    /// </summary>
    public Guid? ControlAccountId { get; set; }

    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public string BusinessId { get; set; } = "default";

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// حساب کنترل
    /// Control account
    /// </summary>
    public Accounting.Account? ControlAccount { get; set; }
    public decimal CurrentBalance { get; set; }
    public string? BankName { get; set; }
    public string? AccountNumber { get; set; }
    public string? AccountType { get; set; }
    public decimal InitialBalance { get; set; }
    public string? BranchName { get; set; }
    public string? BranchCode { get; set; }
    public string? BranchAddress { get; set; }
    public string? BranchPhone { get; set; }
    public string? CardNumber { get; set; }
    public string? Notes { get; set; }
    public string? BankCode { get; set; }
    public string? AccountHolderName { get; set; }
    public string? Description { get; set; }

    /// <summary>
    /// پرداخت‌های فروش از این حساب
    /// Sale payments from this bank account
    /// </summary>
    public ICollection<Dinawin.Erp.Domain.Entities.Accounting.SalePayment> SalePayments { get; set; } = new List<Dinawin.Erp.Domain.Entities.Accounting.SalePayment>();

    /// <summary>
    /// پرداخت‌های خرید از این حساب
    /// Purchase payments from this bank account
    /// </summary>
    public ICollection<Dinawin.Erp.Domain.Entities.Accounting.PurchasePayment> PurchasePayments { get; set; } = new List<Dinawin.Erp.Domain.Entities.Accounting.PurchasePayment>();
}
