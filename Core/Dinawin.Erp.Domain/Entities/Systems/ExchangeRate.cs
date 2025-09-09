using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Systems;

/// <summary>
/// نرخ ارز
/// Exchange Rate
/// </summary>
public class ExchangeRate : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// ارز مبدا
    /// From currency
    /// </summary>
    public string FromCurrency { get; set; } = string.Empty;

    /// <summary>
    /// ارز مقصد
    /// To currency
    /// </summary>
    public string ToCurrency { get; set; } = string.Empty;

    /// <summary>
    /// نرخ ارز
    /// Exchange rate
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// تاریخ نرخ
    /// Rate date
    /// </summary>
    public DateTime RateDate { get; set; }

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// منبع نرخ
    /// Rate source
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }
}
