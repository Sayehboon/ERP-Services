using System.ComponentModel;

namespace Dinawin.Erp.Domain.Enums;

/// <summary>
/// تراز طبیعی حساب
/// </summary>
public enum NormalBalanceEnum
{
    /// <summary>
    /// بدهکار
    /// </summary>
    [Description("بدهکار")]
    Debit = 1,

    /// <summary>
    /// بستانکار
    /// </summary>
    [Description("بستانکار")]
    Credit = 2,

    /// <summary>
    /// خنثی
    /// </summary>
    [Description("خنثی")]
    Neutral = 3
}
