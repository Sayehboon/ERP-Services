using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Treasury;

/// <summary>
/// جریان ابزار مالی
/// Financial Instrument Flow
/// </summary>
public class InstrumentFlow : BaseEntity
{
    /// <summary>
    /// شناسه ابزار
    /// Instrument ID
    /// </summary>
    public Guid InstrumentId { get; set; }

    /// <summary>
    /// تاریخ جریان
    /// Flow date
    /// </summary>
    public DateTime FlowDate { get; set; }

    /// <summary>
    /// نوع جریان
    /// Flow type
    /// </summary>
    public string FlowType { get; set; } = string.Empty;

    /// <summary>
    /// مبلغ
    /// Amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// ابزار مرتبط
    /// Related instrument
    /// </summary>
    public Instrument Instrument { get; set; } = null!;
}
