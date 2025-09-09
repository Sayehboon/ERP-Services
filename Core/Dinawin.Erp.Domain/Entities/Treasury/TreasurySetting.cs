using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Treasury;

public class TreasurySetting : BaseEntity, IAggregateRoot
{
    public Guid BusinessId { get; set; }
    public string DefaultCurrency { get; set; } = "IRR";
    public decimal MaxCashLimit { get; set; } = 0;
    public decimal RequireApprovalAbove { get; set; } = 0;
    public bool AutoReconciliation { get; set; }
    public string CashCountingFrequency { get; set; } = "daily";
    public string BackupFrequency { get; set; } = "daily";
    public string ReceiptTemplate { get; set; } = "standard";
    public bool AllowNegativeBalance { get; set; }
    public bool MultiCurrencySupport { get; set; }
    public string ExchangeRateSource { get; set; } = "central_bank";
}


