using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetAllTasks;
using Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetTaskById;
using Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.SearchTasks;
using Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetTaskProgress;
using Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetTaskStatistics;
using Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.CreateTask;
using Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.UpdateTask;
using TaskDto = Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetAllTasks.TaskDto;
using Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.UpdateTaskProgress;
using Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.UpdateTaskStatus;
using Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.DeleteTask;

namespace Dinawin.Erp.WebApi.Controllers.TaskManagement;

/// <summary>
/// کنترلر مدیریت وظایف
/// </summary>
[Route("api/[controller]")]
public class TasksController : BaseController
{
    /// <summary>
    /// سازنده کنترلر وظایف
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public TasksController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام وظایف
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="projectId">شناسه پروژه</param>
    /// <param name="assignedToUserId">شناسه کاربر مسئول</param>
    /// <param name="createdByUserId">شناسه کاربر ایجاد کننده</param>
    /// <param name="priority">اولویت</param>
    /// <param name="status">وضعیت</param>
    /// <param name="taskType">نوع وظیفه</param>
    /// <param name="isActive">وضعیت فعال بودن</param>
    /// <param name="fromDate">تاریخ شروع از</param>
    /// <param name="toDate">تاریخ شروع تا</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تمام وظایف</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TaskDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetAllTasks(
        [FromQuery] string searchTerm = null,
        [FromQuery] Guid? projectId = null,
        [FromQuery] Guid? assignedToUserId = null,
        [FromQuery] Guid? createdByUserId = null,
        [FromQuery] string priority = null,
        [FromQuery] string status = null,
        [FromQuery] string taskType = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllTasksQuery
            {
                SearchTerm = searchTerm,
                ProjectId = projectId,
                AssignedToUserId = assignedToUserId,
                CreatedByUserId = createdByUserId,
                Priority = priority,
                Status = status,
                TaskType = taskType,
                IsActive = isActive,
                FromDate = fromDate,
                ToDate = toDate,
                Page = page,
                PageSize = pageSize
            };

            var tasks = await _mediator.Send(query);
            return Success(tasks);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست وظایف");
        }
    }

    /// <summary>
    /// دریافت وظیفه بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه وظیفه</param>
    /// <returns>اطلاعات وظیفه</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TaskDto), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetTask(Guid id)
    {
        try
        {
            var query = new GetTaskByIdQuery { Id = id };
            var task = await _mediator.Send(query);
            
            if (task == null)
            {
                return NotFound($"وظیفه با شناسه {id} یافت نشد");
            }
            
            return Success(task);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات وظیفه");
        }
    }

    /// <summary>
    /// دریافت وظایف یک پروژه
    /// </summary>
    /// <param name="projectId">شناسه پروژه</param>
    /// <returns>لیست وظایف پروژه</returns>
    [HttpGet("by-project/{projectId}")]
    [ProducesResponseType(typeof(IEnumerable<TaskDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetTasksByProject(Guid projectId)
    {
        try
        {
            var query = new GetAllTasksQuery { ProjectId = projectId };
            var tasks = await _mediator.Send(query);
            return Success(tasks);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت وظایف پروژه");
        }
    }

    /// <summary>
    /// دریافت وظایف یک کاربر
    /// </summary>
    /// <param name="userId">شناسه کاربر</param>
    /// <returns>لیست وظایف کاربر</returns>
    [HttpGet("by-user/{userId}")]
    [ProducesResponseType(typeof(IEnumerable<TaskDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasksByUser(Guid userId)
    {
        try
        {
            var query = new GetAllTasksQuery { AssignedToUserId = userId };
            var tasks = await _mediator.Send(query);
            return Success(tasks);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت وظایف کاربر");
        }
    }

    /// <summary>
    /// جستجوی وظایف
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="projectId">شناسه پروژه</param>
    /// <param name="assignedToUserId">شناسه کاربر مسئول</param>
    /// <param name="priority">اولویت</param>
    /// <param name="status">وضعیت</param>
    /// <param name="taskType">نوع وظیفه</param>
    /// <param name="maxResults">حداکثر تعداد نتایج</param>
    /// <returns>لیست وظایف مطابق جستجو</returns>
    [HttpGet("search")]
    [ProducesResponseType(typeof(IEnumerable<TaskSearchDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<TaskSearchDto>>> SearchTasks(
        [FromQuery] string searchTerm,
        [FromQuery] Guid? projectId = null,
        [FromQuery] Guid? assignedToUserId = null,
        [FromQuery] string priority = null,
        [FromQuery] string status = null,
        [FromQuery] string taskType = null,
        [FromQuery] int maxResults = 20)
    {
        try
        {
            var query = new SearchTasksQuery
            {
                SearchTerm = searchTerm,
                ProjectId = projectId,
                AssignedToUserId = assignedToUserId,
                Priority = priority,
                Status = status,
                TaskType = taskType,
                MaxResults = maxResults
            };

            var tasks = await _mediator.Send(query);
            return Success(tasks);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در جستجوی وظایف");
        }
    }

    /// <summary>
    /// ایجاد وظیفه جدید
    /// </summary>
    /// <param name="command">دستور ایجاد وظیفه</param>
    /// <returns>شناسه وظیفه ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateTask([FromBody] CreateTaskCommand command)
    {
        try
        {
            var taskId = await _mediator.Send(command);
            return Created(taskId, "وظیفه با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد وظیفه");
        }
    }

    /// <summary>
    /// به‌روزرسانی وظیفه
    /// </summary>
    /// <param name="id">شناسه وظیفه</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateTask(Guid id, [FromBody] UpdateTaskCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success("وظیفه با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی وظیفه");
        }
    }

    /// <summary>
    /// به‌روزرسانی پیشرفت وظیفه
    /// </summary>
    /// <param name="id">شناسه وظیفه</param>
    /// <param name="command">دستور به‌روزرسانی پیشرفت</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPatch("{id}/progress")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateTaskProgress(Guid id, [FromBody] UpdateTaskProgressCommand command)
    {
        try
        {
            command.Id = id;
            await _mediator.Send(command);
            return Success($"پیشرفت وظیفه به {command.Progress}% به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی پیشرفت وظیفه");
        }
    }

    /// <summary>
    /// تغییر وضعیت وظیفه
    /// </summary>
    /// <param name="id">شناسه وظیفه</param>
    /// <param name="command">دستور تغییر وضعیت</param>
    /// <returns>نتیجه تغییر وضعیت</returns>
    [HttpPatch("{id}/status")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateTaskStatus(Guid id, [FromBody] UpdateTaskStatusCommand command)
    {
        try
        {
            command.Id = id;
            await _mediator.Send(command);
            return Success($"وضعیت وظیفه به {command.Status} تغییر یافت");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در تغییر وضعیت وظیفه");
        }
    }

    /// <summary>
    /// حذف وظیفه
    /// </summary>
    /// <param name="id">شناسه وظیفه</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteTask(Guid id)
    {
        try
        {
            var command = new DeleteTaskCommand { Id = id };
            var result = await _mediator.Send(command);
            return Success("وظیفه با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف وظیفه");
        }
    }

    /// <summary>
    /// دریافت پیشرفت وظیفه
    /// </summary>
    /// <param name="id">شناسه وظیفه</param>
    /// <param name="includeDetails">آیا شامل جزئیات باشد</param>
    /// <returns>اطلاعات پیشرفت وظیفه</returns>
    [HttpGet("{id}/progress")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<TaskProgressDto>> GetTaskProgress(Guid id, [FromQuery] bool includeDetails = true)
    {
        try
        {
            var query = new GetTaskProgressQuery
            {
                TaskId = id,
                IncludeDetails = includeDetails
            };

            var progress = await _mediator.Send(query);
            
            if (progress == null)
            {
                return NotFound("وظیفه یافت نشد");
            }

            return Success(progress);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت پیشرفت وظیفه");
        }
    }

    /// <summary>
    /// دریافت آمار وظایف
    /// </summary>
    /// <param name="projectId">شناسه پروژه (اختیاری)</param>
    /// <param name="userId">شناسه کاربر (اختیاری)</param>
    /// <param name="fromDate">تاریخ شروع (اختیاری)</param>
    /// <param name="toDate">تاریخ پایان (اختیاری)</param>
    /// <param name="statisticsType">نوع آمار</param>
    /// <returns>آمار وظایف</returns>
    [HttpGet("statistics")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<TaskStatisticsDto>> GetTaskStatistics(
        [FromQuery] Guid? projectId = null,
        [FromQuery] Guid? userId = null,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] string statisticsType = "overview")
    {
        try
        {
            var query = new GetTaskStatisticsQuery
            {
                ProjectId = projectId,
                UserId = userId,
                FromDate = fromDate,
                ToDate = toDate,
                StatisticsType = statisticsType
            };

            var statistics = await _mediator.Send(query);
            return Success(statistics);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت آمار وظایف");
        }
    }
}
