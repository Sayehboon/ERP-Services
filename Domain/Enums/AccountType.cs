using System.ComponentModel;

namespace Dinawin.Erp.Domain.Enums;

/// <summary>
/// انواع حساب در سیستم حسابداری
/// </summary>
public enum AccountTypeEnum
{
    /// <summary>
    /// دارایی
    /// </summary>
    [Description("دارایی")]
    Asset = 1,

    /// <summary>
    /// بدهی
    /// </summary>
    [Description("بدهی")]
    Liability = 2,

    /// <summary>
    /// حقوق صاحبان سهام
    /// </summary>
    [Description("حقوق صاحبان سهام")]
    Equity = 3,

    /// <summary>
    /// درآمد
    /// </summary>
    [Description("درآمد")]
    Income = 4,

    /// <summary>
    /// هزینه
    /// </summary>
    [Description("هزینه")]
    Expense = 5
}
