using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت پیوست وظیفه
/// Task Attachment entity
/// </summary>
public class TaskAttachment : BaseEntity
{
    /// <summary>
    /// شناسه وظیفه
    /// Task ID
    /// </summary>
    public Guid TaskId { get; set; }

    /// <summary>
    /// نام فایل
    /// File name
    /// </summary>
    public string FileName { get; set; } = string.Empty;

    /// <summary>
    /// مسیر فایل
    /// File path
    /// </summary>
    public string FilePath { get; set; } = string.Empty;

    /// <summary>
    /// نوع فایل
    /// File type
    /// </summary>
    public string FileType { get; set; } = string.Empty;

    /// <summary>
    /// اندازه فایل
    /// File size
    /// </summary>
    public long FileSize { get; set; }

    /// <summary>
    /// توضیحات پیوست
    /// Attachment description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>
    
}
