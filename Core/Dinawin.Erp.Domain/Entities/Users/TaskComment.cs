using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت نظر وظیفه
/// Task Comment entity
/// </summary>
public class TaskComment : BaseEntity
{
    /// <summary>
    /// شناسه وظیفه
    /// Task ID
    /// </summary>
    public Guid TaskId { get; set; }

    /// <summary>
    /// متن نظر
    /// Comment text
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>
    

    /// <summary>
    /// یادداشت‌های نظر
    /// Comment notes
    /// </summary>
    public string? Notes { get; set; }
}
