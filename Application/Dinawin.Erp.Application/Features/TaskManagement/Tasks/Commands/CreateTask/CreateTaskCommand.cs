using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.CreateTask;

/// <summary>
/// دستور ایجاد وظیفه جدید
/// </summary>
public class CreateTaskCommand : IRequest<Guid>
{
    /// <summary>
    /// عنوان وظیفه
    /// </summary>
    [Required(ErrorMessage = "عنوان وظیفه الزامی است")]
    [StringLength(200, ErrorMessage = "عنوان وظیفه نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// شناسه پروژه
    /// </summary>
    public Guid? ProjectId { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToUserId { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    [Required(ErrorMessage = "شناسه کاربر ایجاد کننده الزامی است")]
    public Guid CreatedByUserId { get; set; }

    /// <summary>
    /// اولویت
    /// </summary>
    [Required(ErrorMessage = "اولویت الزامی است")]
    [StringLength(20, ErrorMessage = "اولویت نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Priority { get; set; } = "Medium";

    /// <summary>
    /// وضعیت
    /// </summary>
    [Required(ErrorMessage = "وضعیت الزامی است")]
    [StringLength(20, ErrorMessage = "وضعیت نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Status { get; set; } = "Open";

    /// <summary>
    /// نوع وظیفه
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع وظیفه نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? TaskType { get; set; }

    /// <summary>
    /// درصد پیشرفت
    /// </summary>
    [Range(0, 100, ErrorMessage = "درصد پیشرفت باید بین 0 تا 100 باشد")]
    public int Progress { get; set; } = 0;

    /// <summary>
    /// تاریخ شروع
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// تاریخ تکمیل
    /// </summary>
    public DateTime? CompletedDate { get; set; }

    /// <summary>
    /// تخمین زمان (ساعت)
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "تخمین زمان باید مثبت باشد")]
    public decimal? EstimatedHours { get; set; }

    /// <summary>
    /// زمان صرف شده (ساعت)
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "زمان صرف شده باید مثبت باشد")]
    public decimal? ActualHours { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;
}