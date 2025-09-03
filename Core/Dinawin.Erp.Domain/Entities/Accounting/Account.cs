namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;

/// <summary>
/// موجودیت حساب معین دفتر کل
/// General ledger account entity
/// </summary>
public class Account : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// کد حساب
    /// Account code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نام حساب
    /// Account name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شرح حساب
    /// Account description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه حساب والد
    /// Parent account ID
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public string BusinessId { get; set; } = "default";

    /// <summary>
    /// حساب والد
    /// Parent account
    /// </summary>
    public Account? Parent { get; set; }

    /// <summary>
    /// حساب‌های فرزند
    /// Child accounts
    /// </summary>
    public ICollection<Account> Children { get; set; } = new List<Account>();
}


