namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.DTOs;

/// <summary>
/// مدل انتقال داده آیتم شمارشی
/// </summary>
public sealed class EnumItemDto
{
    /// <summary>
    /// مقدار شمارشی
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// نام انگلیسی
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام فارسی
    /// </summary>
    public string PersianName { get; set; } = string.Empty;
}
