namespace Dinawin.Erp.Application.Features.Models.Queries.GetModelById;

/// <summary>
/// DTO مدل
/// </summary>
public class ModelDto
{
    /// <summary>
    /// شناسه مدل
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام مدل
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات مدل
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه برند
    /// </summary>
    public Guid? BrandId { get; set; }

    /// <summary>
    /// نام برند
    /// </summary>
    public string? BrandName { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// ترتیب نمایش
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// تعداد کالاهای مرتبط
    /// </summary>
    public int ProductCount { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
