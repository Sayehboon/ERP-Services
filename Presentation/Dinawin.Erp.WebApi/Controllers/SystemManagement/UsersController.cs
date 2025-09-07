using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.SystemManagement.Users.Queries.GetAllUsers;
using Dinawin.Erp.Application.Features.SystemManagement.Users.Queries.GetUserById;
using Dinawin.Erp.Application.Features.SystemManagement.Users.Commands.CreateUser;
using Dinawin.Erp.Application.Features.SystemManagement.Users.Commands.UpdateUser;
using Dinawin.Erp.Application.Features.SystemManagement.Users.Commands.DeleteUser;
using Dinawin.Erp.Application.Features.SystemManagement.Users.Commands.ToggleUserStatus;

namespace Dinawin.Erp.WebApi.Controllers.SystemManagement;

/// <summary>
/// کنترلر مدیریت کاربران سیستم
/// </summary>
[Route("api/[controller]")]
public class UsersController : BaseController
{
    /// <summary>
    /// سازنده کنترلر کاربران
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام کاربران
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="roleId">شناسه نقش</param>
    /// <param name="companyId">شناسه شرکت</param>
    /// <param name="isActive">وضعیت فعال بودن</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تمام کاربران</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllUsers(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? roleId = null,
        [FromQuery] Guid? companyId = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllUsersQuery
            {
                SearchTerm = searchTerm,
                RoleId = roleId,
                CompanyId = companyId,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var users = await _mediator.Send(query);
            return Success(users);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست کاربران");
        }
    }

    /// <summary>
    /// دریافت کاربر بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <returns>اطلاعات کاربر</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetUser(Guid id)
    {
        try
        {
            var query = new GetUserByIdQuery { Id = id };
            var user = await _mediator.Send(query);
            
            if (user == null)
            {
                return NotFound($"کاربر با شناسه {id} یافت نشد");
            }
            
            return Success(user);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات کاربر");
        }
    }

    /// <summary>
    /// دریافت کاربران فعال
    /// </summary>
    /// <returns>لیست کاربران فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetActiveUsers()
    {
        try
        {
            var query = new GetAllUsersQuery { IsActive = true };
            var users = await _mediator.Send(query);
            return Success(users);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت کاربران فعال");
        }
    }

    /// <summary>
    /// ایجاد کاربر جدید
    /// </summary>
    /// <param name="command">دستور ایجاد کاربر</param>
    /// <returns>شناسه کاربر ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        try
        {
            var userId = await _mediator.Send(command);
            return Created(userId, "کاربر با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد کاربر");
        }
    }

    /// <summary>
    /// به‌روزرسانی کاربر
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UpdateUserCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success("کاربر با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی کاربر");
        }
    }

    /// <summary>
    /// تغییر وضعیت کاربر
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <param name="isActive">وضعیت فعال/غیرفعال</param>
    /// <returns>نتیجه تغییر وضعیت</returns>
    [HttpPatch("{id}/toggle-status")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> ToggleUserStatus(Guid id, [FromBody] ToggleUserStatusCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success(result, $"وضعیت کاربر با موفقیت به {(command.IsActive ? "فعال" : "غیرفعال")} تغییر یافت");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در تغییر وضعیت کاربر");
        }
    }

    /// <summary>
    /// حذف کاربر
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        try
        {
            var command = new DeleteUserCommand { Id = id };
            var result = await _mediator.Send(command);
            return Success("کاربر با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف کاربر");
        }
    }
}
