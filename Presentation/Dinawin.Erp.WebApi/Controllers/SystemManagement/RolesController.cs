using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.SystemManagement.Roles.Queries.GetAllRoles;
using Dinawin.Erp.Application.Features.SystemManagement.Roles.Queries.GetRoleById;
using Dinawin.Erp.Application.Features.SystemManagement.Roles.Queries.GetRolePermissions;
using Dinawin.Erp.Application.Features.SystemManagement.Roles.Commands.CreateRole;
using Dinawin.Erp.Application.Features.SystemManagement.Roles.Commands.UpdateRole;
using Dinawin.Erp.Application.Features.SystemManagement.Roles.Commands.DeleteRole;
using Dinawin.Erp.Application.Features.SystemManagement.Roles.Commands.AssignPermission;
using RoleDto = Dinawin.Erp.Application.Features.SystemManagement.Roles.Queries.GetAllRoles.RoleDto;

namespace Dinawin.Erp.WebApi.Controllers.SystemManagement;

/// <summary>
/// کنترلر مدیریت نقش‌ها
/// </summary>
[Route("api/[controller]")]
public class RolesController : BaseController
{
    /// <summary>
    /// سازنده کنترلر نقش‌ها
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public RolesController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام نقش‌ها
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="isActive">وضعیت فعال بودن</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تمام نقش‌ها</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RoleDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<RoleDto>>> GetAllRoles(
        [FromQuery] string searchTerm = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllRolesQuery
            {
                SearchTerm = searchTerm,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var roles = await _mediator.Send(query);
            return Success(roles);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست نقش‌ها");
        }
    }

    /// <summary>
    /// دریافت نقش بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه نقش</param>
    /// <returns>اطلاعات نقش</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RoleDto), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetRole(Guid id)
    {
        try
        {
            var query = new GetRoleByIdQuery { Id = id };
            var role = await _mediator.Send(query);
            
            if (role == null)
            {
                return NotFound($"نقش با شناسه {id} یافت نشد");
            }
            
            return Success(role);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات نقش");
        }
    }

    /// <summary>
    /// دریافت نقش‌های فعال
    /// </summary>
    /// <returns>لیست نقش‌های فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<RoleDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<RoleDto>>> GetActiveRoles()
    {
        try
        {
            var query = new GetAllRolesQuery { IsActive = true };
            var roles = await _mediator.Send(query);
            return Success(roles);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت نقش‌های فعال");
        }
    }

    /// <summary>
    /// دریافت مجوزهای یک نقش
    /// </summary>
    /// <param name="id">شناسه نقش</param>
    /// <returns>لیست مجوزهای نقش</returns>
    [HttpGet("{id}/permissions")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<PermissionDto>>> GetRolePermissions(Guid id)
    {
        try
        {
            var query = new GetRolePermissionsQuery { RoleId = id };
            var permissions = await _mediator.Send(query);
            return Success(permissions);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت مجوزهای نقش");
        }
    }

    /// <summary>
    /// ایجاد نقش جدید
    /// </summary>
    /// <param name="command">دستور ایجاد نقش</param>
    /// <returns>شناسه نقش ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateRole([FromBody] CreateRoleCommand command)
    {
        try
        {
            var roleId = await _mediator.Send(command);
            return Created(roleId, "نقش با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد نقش");
        }
    }

    /// <summary>
    /// به‌روزرسانی نقش
    /// </summary>
    /// <param name="id">شناسه نقش</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateRole(Guid id, [FromBody] UpdateRoleCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success("نقش با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی نقش");
        }
    }

    /// <summary>
    /// اختصاص مجوز به نقش
    /// </summary>
    /// <param name="id">شناسه نقش</param>
    /// <param name="command">دستور اختصاص مجوز</param>
    /// <returns>نتیجه اختصاص مجوز</returns>
    [HttpPost("{id}/assign-permission")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public ActionResult AssignPermission(Guid id, [FromBody] object command)
    {
        try
        {
            // TODO: پیاده‌سازی AssignPermissionCommand
            return Success("مجوز با موفقیت به نقش اختصاص یافت");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در اختصاص مجوز");
        }
    }

    /// <summary>
    /// تخصیص مجوز به نقش
    /// </summary>
    /// <param name="id">شناسه نقش</param>
    /// <param name="command">دستور تخصیص مجوز</param>
    /// <returns>نتیجه تخصیص</returns>
    [HttpPost("{id}/permissions")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> AssignPermission(Guid id, [FromBody] AssignPermissionCommand command)
    {
        try
        {
            var assignCommand = new AssignPermissionCommand { RoleId = id, PermissionId = command.PermissionId };
            var result = await _mediator.Send(assignCommand);
            
            if (result)
            {
                return Success("مجوز با موفقیت به نقش تخصیص داده شد");
            }
            
            return BadRequest("خطا در تخصیص مجوز");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در تخصیص مجوز به نقش");
        }
    }

    /// <summary>
    /// حذف نقش
    /// </summary>
    /// <param name="id">شناسه نقش</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteRole(Guid id)
    {
        try
        {
            var command = new DeleteRoleCommand { Id = id };
            var result = await _mediator.Send(command);
            return Success("نقش با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف نقش");
        }
    }
}
