using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// موجودیت سال محصول
/// Product Year entity
/// </summary>
public class Year : BaseEntity
{
    /// <summary>
    /// سال
    /// Year
    /// </summary>
    public int YearValue { get; set; }

    /// <summary>
    /// توضیحات سال
    /// Year description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// وضعیت فعال بودن سال
    /// Year active status
    /// </summary>
    public bool IsActive { get; set; } = true;
    public Guid TrimId { get; set; }
}
