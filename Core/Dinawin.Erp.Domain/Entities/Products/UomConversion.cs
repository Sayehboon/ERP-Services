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
    public decimal Factor { get; set; }

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
}


