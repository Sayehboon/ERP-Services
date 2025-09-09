using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// موجودیت مدل محصول
/// Product Model entity
/// </summary>
public class Model : BaseEntity
{
    /// <summary>
    /// نام مدل
    /// Model name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد مدل
    /// Model code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات مدل
    /// Model description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه برند
    /// Brand ID
    /// </summary>
    public Guid BrandId { get; set; }

    /// <summary>
    /// وضعیت فعال بودن مدل
    /// Model active status
    /// </summary>
    public bool IsActive { get; set; } = true;
    public Guid CategoryId { get; set; }
    public string YearRange { get; set; }
}
