namespace Dinawin.Erp.Application.Features.Years.Queries.GetAllYears;

/// <summary>
/// DTO سال
/// </summary>
public class YearDto
{
    /// <summary>
    /// شناسه سال
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// سال
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// توضیحات سال
    /// </summary>
    public string? Description { get; set; }

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
