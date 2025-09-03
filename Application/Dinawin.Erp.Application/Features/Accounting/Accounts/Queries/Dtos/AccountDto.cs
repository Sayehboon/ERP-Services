namespace Dinawin.Erp.Application.Features.Accounting.Accounts.Queries.Dtos;

/// <summary>
/// DTO حساب
/// Account DTO
/// </summary>
public class AccountDto
{
    /// <summary>
    /// شناسه
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// کد
    /// Code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نام
    /// Name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// شرح
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه حساب والد
    /// Parent account ID
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public string BusinessId { get; set; } = string.Empty;
}


