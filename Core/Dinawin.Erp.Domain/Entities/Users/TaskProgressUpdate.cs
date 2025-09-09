using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت بروزرسانی پیشرفت وظیفه
/// Task Progress Update entity
/// </summary>
public class TaskProgressUpdate : BaseEntity
{
    /// <summary>
    /// شناسه وظیفه
    /// Task ID
    /// </summary>
    public Guid TaskId { get; set; }

    /// <summary>
    /// درصد پیشرفت قبلی
    /// Previous progress percentage
    /// </summary>
    public int PreviousProgress { get; set; }

    /// <summary>
    /// درصد پیشرفت جدید
    /// New progress percentage
    /// </summary>
    public int NewProgress { get; set; }

    /// <summary>
    /// توضیحات بروزرسانی
    /// Update description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>
    

    /// <summary>
    /// یادداشت‌های بروزرسانی
    /// Update notes
    /// </summary>
    public string? Notes { get; set; }
}
