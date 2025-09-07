using MediatR;

namespace Dinawin.Erp.Application.Features.Customers.Queries.SearchCustomers;

/// <summary>
/// پرس‌وجو جستجوی مشتریان
/// </summary>
public sealed class SearchCustomersQuery : IRequest<IEnumerable<CustomerSearchDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    [Required(ErrorMessage = "عبارت جستجو الزامی است")]
    [StringLength(100, ErrorMessage = "عبارت جستجو نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string SearchTerm { get; set; } = string.Empty;

    /// <summary>
    /// نوع مشتری برای فیلتر
    /// </summary>
    public string? CustomerType { get; set; }

    /// <summary>
    /// شهر برای فیلتر
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// استان برای فیلتر
    /// </summary>
    public string? Province { get; set; }

    /// <summary>
    /// کشور برای فیلتر
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// وضعیت فعال بودن برای فیلتر
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// حداکثر تعداد نتایج
    /// </summary>
    [Range(1, 100, ErrorMessage = "تعداد نتایج باید بین 1 تا 100 باشد")]
    public int MaxResults { get; set; } = 20;
}
