namespace Dinawin.Erp.Application.Features.Customers.Queries.SearchCustomers;

/// <summary>
/// مدل انتقال داده جستجوی مشتری
/// </summary>
public sealed class CustomerSearchDto
{
    /// <summary>
    /// شناسه مشتری
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام مشتری
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد مشتری
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نوع مشتری
    /// </summary>
    public string CustomerType { get; set; } = string.Empty;

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// نام تماس
    /// </summary>
    public string ContactName { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// آدرس ایمیل
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// شهر
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// استان
    /// </summary>
    public string Province { get; set; }

    /// <summary>
    /// کشور
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// آیا مشتری فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// امتیاز تطبیق جستجو
    /// </summary>
    public int MatchScore { get; set; }
}
