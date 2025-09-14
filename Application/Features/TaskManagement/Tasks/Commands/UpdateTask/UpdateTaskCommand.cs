using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.UpdateTask;

/// <summary>
/// دستور به‌روزرسانی وظیفه
/// </summary>
public sealed class UpdateTaskCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه وظیفه
    /// </summary>
    [Required(ErrorMessage = "شناسه وظیفه الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// عنوان وظیفه
    /// </summary>
    [Required(ErrorMessage = "عنوان وظیفه الزامی است")]
    [StringLength(200, ErrorMessage = "عنوان وظیفه نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات وظیفه
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string Description { get; set; }

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
    public Guid? CreatedByUserId { get; set; }

    /// <summary>
    /// اولویت وظیفه
    /// </summary>
    [Required(ErrorMessage = "اولویت وظیفه الزامی است")]
    [StringLength(20, ErrorMessage = "اولویت نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت وظیفه
    /// </summary>
    [Required(ErrorMessage = "وضعیت وظیفه الزامی است")]
    [StringLength(20, ErrorMessage = "وضعیت نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// نوع وظیفه
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع وظیفه نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string TaskType { get; set; }

    /// <summary>
    /// تاریخ شروع برنامه‌ریزی شده
    /// </summary>
    public DateTime? PlannedStartDate { get; set; }

    /// <summary>
    /// تاریخ پایان برنامه‌ریزی شده
    /// </summary>
    public DateTime? PlannedEndDate { get; set; }

    /// <summary>
    /// تاریخ شروع واقعی
    /// </summary>
    public DateTime? ActualStartDate { get; set; }

    /// <summary>
    /// تاریخ پایان واقعی
    /// </summary>
    public DateTime? ActualEndDate { get; set; }

    /// <summary>
    /// درصد پیشرفت (0-100)
    /// </summary>
    [Range(0, 100, ErrorMessage = "درصد پیشرفت باید بین 0 تا 100 باشد")]
    public int ProgressPercentage { get; set; } = 0;

    /// <summary>
    /// تخمین زمان (ساعت)
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "تخمین زمان نمی‌تواند منفی باشد")]
    public decimal? EstimatedHours { get; set; }

    /// <summary>
    /// زمان صرف شده (ساعت)
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "زمان صرف شده نمی‌تواند منفی باشد")]
    public decimal? ActualHours { get; set; }

    /// <summary>
    /// برچسب‌ها
    /// </summary>
    [StringLength(500, ErrorMessage = "برچسب‌ها نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string Tags { get; set; }

    /// <summary>
    /// آیا وظیفه فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
