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
    public required string Name { get; set; }

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
}
