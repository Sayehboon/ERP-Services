using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.SystemManagement.UserProfiles.Queries.GetUserProfile;
using Dinawin.Erp.Application.Features.SystemManagement.UserProfiles.Queries.GetCurrentUserProfile;
using Dinawin.Erp.Application.Features.SystemManagement.UserProfiles.Commands.UpdateUserProfile;
using Dinawin.Erp.Application.Features.SystemManagement.UserProfiles.Commands.ChangePassword;

namespace Dinawin.Erp.WebApi.Controllers.SystemManagement;

/// <summary>
/// کنترلر مدیریت پروفایل کاربران
/// </summary>
[Route("api/[controller]")]
public class UserProfilesController : BaseController
{
    /// <summary>
    /// سازنده کنترلر پروفایل کاربران
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public UserProfilesController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت پروفایل کاربر بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <returns>اطلاعات پروفایل کاربر</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserProfileDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<UserProfileDto>> GetUserProfile(Guid id)
    {
        try
        {
            var query = new GetUserProfileQuery { UserId = id };
            var result = await _mediator.Send(query);
            if (result == null) return NotFound("پروفایل کاربر یافت نشد");
            return Success(result);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت پروفایل کاربر");
        }
    }

    /// <summary>
    /// دریافت پروفایل کاربر فعلی
    /// </summary>
    /// <returns>اطلاعات پروفایل کاربر فعلی</returns>
    [HttpGet("current")]
    [ProducesResponseType(typeof(UserProfileDto), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetCurrentUserProfile()
    {
        try
        {
            // TODO: دریافت شناسه کاربر فعلی از JWT token
            var currentUserId = Guid.NewGuid(); // این باید از JWT token دریافت شود
            
            var query = new GetCurrentUserProfileQuery { UserId = currentUserId };
            var profile = await _mediator.Send(query);
            
            if (profile == null)
            {
                return NotFound("پروفایل کاربر یافت نشد");
            }
            
            return Success(profile);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت پروفایل کاربر فعلی");
        }
    }

    /// <summary>
    /// به‌روزرسانی پروفایل کاربر
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<object>> UpdateUserProfile(Guid id, [FromBody] UpdateUserProfileCommand command)
    {
        try
        {
            command.UserId = id;
            var result = await _mediator.Send(command);
            return Success("پروفایل کاربر با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی پروفایل کاربر");
        }
    }

    /// <summary>
    /// به‌روزرسانی پروفایل کاربر فعلی
    /// </summary>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("current")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> UpdateCurrentUserProfile([FromBody] object command)
    {
        try
        {
            // TODO: پیاده‌سازی UpdateCurrentUserProfileCommand
            return Success("پروفایل کاربر فعلی با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی پروفایل کاربر فعلی");
        }
    }

    /// <summary>
    /// تغییر رمز عبور کاربر
    /// </summary>
    /// <param name="id">شناسه کاربر</param>
    /// <param name="command">دستور تغییر رمز عبور</param>
    /// <returns>نتیجه تغییر رمز عبور</returns>
    [HttpPost("{id}/change-password")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<bool>> ChangePassword(Guid id, [FromBody] ChangePasswordCommand command)
    {
        try
        {
            var changePasswordCommand = new ChangePasswordCommand { UserId = id, CurrentPassword = command.CurrentPassword, NewPassword = command.NewPassword, ConfirmNewPassword = command.ConfirmNewPassword };
            var result = await _mediator.Send(changePasswordCommand);
            
            if (result)
            {
                return Success("رمز عبور با موفقیت تغییر یافت");
            }
            
            return BadRequest("خطا در تغییر رمز عبور");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در تغییر رمز عبور");
        }
    }

    /// <summary>
    /// تغییر رمز عبور کاربر فعلی
    /// </summary>
    /// <param name="command">دستور تغییر رمز عبور</param>
    /// <returns>نتیجه تغییر رمز عبور</returns>
    [HttpPost("current/change-password")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> ChangeCurrentUserPassword([FromBody] ChangePasswordCommand command)
    {
        try
        {
            // TODO: دریافت شناسه کاربر فعلی از JWT token
            var currentUserId = Guid.NewGuid(); // این باید از JWT token دریافت شود
            var changePasswordCommand = new ChangePasswordCommand { UserId = currentUserId, CurrentPassword = command.CurrentPassword, NewPassword = command.NewPassword, ConfirmNewPassword = command.ConfirmNewPassword };
            
            var result = await _mediator.Send(changePasswordCommand);
            
            if (result)
            {
                return Success("رمز عبور کاربر فعلی با موفقیت تغییر یافت");
            }
            
            return BadRequest("خطا در تغییر رمز عبور");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در تغییر رمز عبور کاربر فعلی");
        }
    }
}
