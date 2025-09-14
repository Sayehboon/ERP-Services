namespace Dinawin.Erp.Application.Features.Accounting.Customers.Queries.Dtos;

/// <summary>
/// DTO مشتری
/// Customer DTO
/// </summary>
public class CustomerDto
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
}


