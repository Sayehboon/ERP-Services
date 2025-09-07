using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Vendors.Queries.SearchVendors;

/// <summary>
/// پرس‌وجو جستجوی تامین‌کنندگان
/// </summary>
public sealed class SearchVendorsQuery : IRequest<IEnumerable<VendorSearchDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    [Required(ErrorMessage = "عبارت جستجو الزامی است")]
    [StringLength(100, ErrorMessage = "عبارت جستجو نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string SearchTerm { get; set; } = string.Empty;

    /// <summary>
    /// نوع تامین‌کننده برای فیلتر
    /// </summary>
    public string? VendorType { get; set; }

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
