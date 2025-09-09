using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// موجودیت برند
/// Brand entity
/// </summary>
public class Brand : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام برند
    /// Brand name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// توضیحات برند
    /// Brand description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// آدرس لوگو
    /// Logo URL
    /// </summary>
    public string? LogoUrl { get; set; }

    /// <summary>
    /// وب‌سایت برند
    /// Brand website
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// ترتیب نمایش
    /// Display order
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// کالاهای این برند
    /// Products of this brand
    /// </summary>
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public string Code { get; set; }
    public string? Country { get; set; }
    public Guid? CategoryId { get; set; }
}
