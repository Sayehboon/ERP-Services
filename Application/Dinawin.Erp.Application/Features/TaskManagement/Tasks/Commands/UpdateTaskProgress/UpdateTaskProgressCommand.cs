using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.UpdateTaskProgress;

/// <summary>
/// دستور به‌روزرسانی پیشرفت وظیفه
/// </summary>
public class UpdateTaskProgressCommand : IRequest
{
    /// <summary>
    /// شناسه وظیفه
    /// </summary>
    [Required(ErrorMessage = "شناسه وظیفه الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// درصد پیشرفت
    /// </summary>
    [Required(ErrorMessage = "درصد پیشرفت الزامی است")]
    [Range(0, 100, ErrorMessage = "درصد پیشرفت باید بین 0 تا 100 باشد")]
    public int Progress { get; set; }

    /// <summary>
    /// زمان صرف شده (ساعت)
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "زمان صرف شده باید مثبت باشد")]
    public decimal? ActualHours { get; set; }

    /// <summary>
    /// یادداشت
    /// </summary>
    [StringLength(500, ErrorMessage = "یادداشت نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Note { get; set; }
}
