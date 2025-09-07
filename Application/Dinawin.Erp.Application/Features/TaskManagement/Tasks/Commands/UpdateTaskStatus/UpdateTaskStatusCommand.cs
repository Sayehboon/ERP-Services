using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.UpdateTaskStatus;

/// <summary>
/// دستور تغییر وضعیت وظیفه
/// </summary>
public class UpdateTaskStatusCommand : IRequest
{
    /// <summary>
    /// شناسه وظیفه
    /// </summary>
    [Required(ErrorMessage = "شناسه وظیفه الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// وضعیت جدید
    /// </summary>
    [Required(ErrorMessage = "وضعیت الزامی است")]
    [StringLength(20, ErrorMessage = "وضعیت نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// یادداشت
    /// </summary>
    [StringLength(500, ErrorMessage = "یادداشت نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Note { get; set; }
}
