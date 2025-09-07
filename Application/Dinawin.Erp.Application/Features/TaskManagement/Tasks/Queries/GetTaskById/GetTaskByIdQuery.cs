using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetTaskById;

/// <summary>
/// پرس‌وجو دریافت وظیفه بر اساس شناسه
/// </summary>
public sealed class GetTaskByIdQuery : IRequest<TaskDto?>
{
    /// <summary>
    /// شناسه وظیفه
    /// </summary>
    [Required(ErrorMessage = "شناسه وظیفه الزامی است")]
    public Guid Id { get; set; }
}
