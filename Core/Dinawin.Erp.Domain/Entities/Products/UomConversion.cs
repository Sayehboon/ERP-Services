namespace Dinawin.Erp.Domain.Entities.Products;

using Dinawin.Erp.Domain.Common;

/// <summary>
/// موجودیت تبدیل واحد
/// Unit of Measure conversion entity
/// </summary>
public class UomConversion : BaseEntity
{
    /// <summary>
    /// شناسه واحد مبدا
    /// From unit id
    /// </summary>
    public Guid FromUomId { get; set; }

    /// <summary>
    /// شناسه واحد مقصد
    /// To unit id
    /// </summary>
    public Guid ToUomId { get; set; }

    /// <summary>
    /// ضریب تبدیل (از → به)
    /// Conversion factor (from → to)
    /// </summary>
    public decimal ConversionFactor { get; set; }

    /// <summary>
    /// ناوبری به واحد مبدا
    /// Navigation to from unit
    /// </summary>
    public UnitOfMeasure? FromUom { get; set; }

    /// <summary>
    /// ناوبری به واحد مقصد
    /// Navigation to to unit
    /// </summary>
    public UnitOfMeasure? ToUom { get; set; }

    /// <summary>
    /// نام تبدیل
    /// Conversion name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// توضیحات تبدیل
    /// Conversion description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;
}


