namespace Dinawin.Erp.Application.Features.Brands.Queries.GetBrandById;

/// <summary>
/// DTO برای نمایش اطلاعات برند
/// Brand information DTO
/// </summary>
public class BrandDto
{
    /// <summary>
    /// شناسه برند
    /// Brand ID
    /// </summary>
    public Guid Id { get; set; }

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
    public string? Description { get; set; }

    /// <summary>
    /// کشور برند
    /// Brand country
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// وب‌سایت برند
    /// Brand website
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// URL لوگو برند
    /// Brand logo URL
    /// </summary>
    public string? LogoUrl { get; set; }

    /// <summary>
    /// وضعیت فعال بودن برند
    /// Brand active status
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// شناسه دسته‌بندی
    /// Category ID
    /// </summary>
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// نام دسته‌بندی
    /// Category name
    /// </summary>
    public string? CategoryName { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// Created date
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین بروزرسانی
    /// Last updated date
    /// </summary>
    public DateTime UpdatedAt { get; set; }
    public int ProductCount { get; internal set; }
}
