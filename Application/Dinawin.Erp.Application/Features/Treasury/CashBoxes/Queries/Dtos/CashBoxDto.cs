namespace Dinawin.Erp.Application.Features.Treasury.CashBoxes.Queries.Dtos;

/// <summary>
/// DTO صندوق نقدی
/// Cash box DTO
/// </summary>
public class CashBoxDto
{
    /// <summary>
    /// شناسه
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام
    /// Name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// مکان
    /// Location
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public string BusinessId { get; set; } = string.Empty;

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; }
}
