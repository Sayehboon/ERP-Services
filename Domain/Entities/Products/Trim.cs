using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// موجودیت تریم محصول
/// Product Trim entity
/// </summary>
public class Trim : BaseEntity
{
    /// <summary>
    /// نام تریم
    /// Trim name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد تریم
    /// Trim code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات تریم
    /// Trim description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// شناسه مدل
    /// Model ID
    /// </summary>
    public Guid ModelId { get; set; }

    /// <summary>
    /// وضعیت فعال بودن تریم
    /// Trim active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// مدل مرتبط
    /// Related model
    /// </summary>
    public Model? Model { get; set; }

    /// <summary>
    /// ترتیب نمایش
    /// Sort order
    /// </summary>
    public int SortOrder { get; set; } = 0;

    /// <summary>
    /// محصولات این تریم
    /// Products of this trim
    /// </summary>
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public string Engine { get; set; }
    public string Transmission { get; set; }
    public string Drivetrain { get; set; }
}
