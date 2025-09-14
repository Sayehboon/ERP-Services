using MediatR;

namespace Dinawin.Erp.Application.Features.Vendors.Queries.GetVendorProducts;

/// <summary>
/// پرس‌وجو دریافت محصولات تامین‌کننده
/// </summary>
public sealed class GetVendorProductsQuery : IRequest<IEnumerable<VendorProductDto>>
{
    /// <summary>
    /// شناسه تامین‌کننده
    /// </summary>
    public required Guid VendorId { get; init; }

    /// <summary>
    /// آیا فقط محصولات فعال را برگرداند
    /// </summary>
    public bool? IsActive { get; init; }

    /// <summary>
    /// دسته‌بندی محصول (اختیاری)
    /// </summary>
    public Guid? CategoryId { get; init; }

    /// <summary>
    /// جستجو در نام یا کد محصول
    /// </summary>
    public string SearchTerm { get; init; }
}
