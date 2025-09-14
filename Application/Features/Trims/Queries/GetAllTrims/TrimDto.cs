namespace Dinawin.Erp.Application.Features.Trims.Queries.GetAllTrims;

/// <summary>
/// DTO تریم
/// </summary>
public class TrimDto
{
    /// <summary>
    /// شناسه تریم
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام تریم
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات تریم
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// شناسه مدل
    /// </summary>
    public Guid? ModelId { get; set; }

    /// <summary>
    /// نام مدل
    /// </summary>
    public string ModelName { get; set; }

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
