using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت زیروظیفه
/// SubTask entity
/// </summary>
public class SubTask : BaseEntity
{
    /// <summary>
    /// عنوان زیروظیفه
    /// SubTask title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات زیروظیفه
    /// SubTask description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// وضعیت زیروظیفه
    /// SubTask status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// اولویت زیروظیفه
    /// SubTask priority
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ شروع زیروظیفه
    /// SubTask start date
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان زیروظیفه
    /// SubTask end date
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// تاریخ تکمیل زیروظیفه
    /// SubTask completion date
    /// </summary>
    public DateTime? CompletedDate { get; set; }

    /// <summary>
    /// درصد پیشرفت زیروظیفه
    /// SubTask progress percentage
    /// </summary>
    public int ProgressPercentage { get; set; }

    /// <summary>
    /// شناسه وظیفه والد
    /// Parent task ID
    /// </summary>
    public Guid TaskId { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>
    

    /// <summary>
    /// شناسه کاربر مسئول
    /// Assigned to user ID
    /// </summary>
    public Guid? AssignedTo { get; set; }

    /// <summary>
    /// یادداشت‌های زیروظیفه
    /// SubTask notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// وضعیت فعال بودن زیروظیفه
    /// SubTask active status
    /// </summary>
    public bool IsActive { get; set; } = true;
}
