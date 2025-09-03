namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;

/// <summary>
/// موجودیت مشتری
/// Customer entity
/// </summary>
public class Customer : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// کد مشتری
    /// Customer code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نام مشتری
    /// Customer name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;
}


