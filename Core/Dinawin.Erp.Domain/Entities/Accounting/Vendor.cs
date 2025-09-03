namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;

/// <summary>
/// موجودیت تامین‌کننده
/// Vendor entity
/// </summary>
public class Vendor : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// کد تامین‌کننده
    /// Vendor code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نام تامین‌کننده
    /// Vendor name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;
}


