using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت فعالیت وظیفه
/// Task Activity entity
/// </summary>
public class TaskActivity : BaseEntity
{
    /// <summary>
    /// شناسه وظیفه
    /// Task ID
    /// </summary>
    public Guid TaskId { get; set; }

    /// <summary>
    /// نوع فعالیت
    /// Activity type
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات فعالیت
    /// Activity description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>
    

    /// <summary>
    /// یادداشت‌های فعالیت
    /// Activity notes
    /// </summary>
    public string? Notes { get; set; }
}
