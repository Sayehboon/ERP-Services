namespace Dinawin.Erp.Application.Features.Treasury.BankAccounts.Queries.Dtos;

/// <summary>
/// DTO حساب بانکی
/// Bank account DTO
/// </summary>
public class BankAccountDto
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
    /// شماره IBAN
    /// IBAN number
    /// </summary>
    public string? Iban { get; set; }

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// شناسه حساب کنترل
    /// Control account ID
    /// </summary>
    public Guid? ControlAccountId { get; set; }

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

    /// <summary>
    /// تاریخ ایجاد
    /// Created at
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
