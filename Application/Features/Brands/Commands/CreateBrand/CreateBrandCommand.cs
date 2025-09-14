using MediatR;

namespace Dinawin.Erp.Application.Features.Brands.Commands.CreateBrand;

/// <summary>
/// دستور ایجاد برند جدید
/// Command for creating a new brand
/// </summary>
public class CreateBrandCommand : IRequest<Guid>
{
    /// <summary>
    /// نام برند
    /// Brand name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد برند
    /// Brand code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات برند
    /// Brand description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// کشور سازنده
    /// Country of origin
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// آدرس وب‌سایت
    /// Website URL
    /// </summary>
    public string Website { get; set; }

    /// <summary>
    /// آدرس لوگو
    /// Logo URL
    /// </summary>
    public string LogoUrl { get; set; }

    /// <summary>
    /// وضعیت فعال بودن برند
    /// Brand active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شناسه دسته‌بندی
    /// Category ID
    /// </summary>
    public Guid? CategoryId { get; set; }
}
