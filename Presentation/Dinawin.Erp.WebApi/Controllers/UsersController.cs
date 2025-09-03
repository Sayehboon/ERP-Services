using Dinawin.Erp.Application.Features.Users.Commands.ToggleUserStatus;
using Dinawin.Erp.Application.Features.Users.Queries.GetAllUsers;
using Dinawin.Erp.Application.Features.Users.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کنترلر مدیریت کاربران
/// Controller for managing users
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// سازنده کنترلر کاربران
    /// Users controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// دریافت لیست تمام کاربران
    /// Gets all users with optional filtering
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="companyId">شناسه شرکت</param>
    /// <param name="departmentId">شناسه بخش</param>
    /// <param name="roleId">شناسه نقش</param>
    /// <param name="isActive">وضعیت فعال/غیرفعال</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست کاربران</returns>
    /// <response code="200">لیست کاربران با موفقیت بازگردانده شد</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserProfileDto>), 200)]
    public async Task<ActionResult<IEnumerable<UserProfileDto>>> GetAllUsers(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? companyId = null,
        [FromQuery] Guid? departmentId = null,
        [FromQuery] Guid? roleId = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        var query = new GetAllUsersQuery
        {
            SearchTerm = searchTerm,
            CompanyId = companyId,
            DepartmentId = departmentId,
            RoleId = roleId,
            IsActive = isActive,
            Page = page,
            PageSize = pageSize
        };

        var users = await _mediator.Send(query);
        return Ok(users);
    }

    /// <summary>
    /// دریافت کاربر با شناسه
    /// Gets a user by ID
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <returns>اطلاعات کاربر</returns>
    /// <response code="200">کاربر پیدا شد</response>
    /// <response code="404">کاربر پیدا نشد</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserProfileDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<UserProfileDto>> GetUser(Guid id)
    {
        // TODO: Implement GetUserByIdQuery
        await Task.CompletedTask;
        return NotFound($"کاربر با شناسه {id} پیدا نشد");
    }

    /// <summary>
    /// تغییر وضعیت کاربر
    /// Toggle user status (active/inactive)
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <param name="currentStatus">وضعیت فعلی کاربر</param>
    /// <returns>نتیجه تغییر وضعیت</returns>
    /// <response code="200">وضعیت کاربر با موفقیت تغییر کرد</response>
    /// <response code="404">کاربر پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPatch("{id}/toggle-status")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> ToggleUserStatus(Guid id, [FromBody] bool currentStatus)
    {
        try
        {
            var command = new ToggleUserStatusCommand
            {
                UserId = id,
                CurrentStatus = currentStatus
            };

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound($"کاربر با شناسه {id} پیدا نشد");
            }

            return Ok(new { message = "وضعیت کاربر با موفقیت تغییر کرد" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "خطا در تغییر وضعیت کاربر", error = ex.Message });
        }
    }

    /// <summary>
    /// ایجاد کاربر جدید
    /// Creates a new user
    /// </summary>
    /// <returns>شناسه کاربر ایجاد شده</returns>
    /// <response code="201">کاربر با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateUser()
    {
        // TODO: Implement CreateUserCommand
        await Task.CompletedTask;
        return BadRequest(new { message = "ایجاد کاربر - در حال توسعه" });
    }

    /// <summary>
    /// ویرایش کاربر
    /// Updates an existing user
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <returns>نتیجه ویرایش</returns>
    /// <response code="200">کاربر با موفقیت ویرایش شد</response>
    /// <response code="404">کاربر پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateUser(Guid id)
    {
        // TODO: Implement UpdateUserCommand
        await Task.CompletedTask;
        return Ok(new { message = "کاربر با موفقیت ویرایش شد" });
    }
}
