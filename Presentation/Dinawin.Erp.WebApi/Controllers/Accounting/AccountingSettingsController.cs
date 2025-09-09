using Dinawin.Erp.Application.Features.Accounting.Settings.Commands.UpsertAccountingSettings;
using Dinawin.Erp.Application.Features.Accounting.Settings.Queries.GetAccountingSettings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers.Accounting;

/// <summary>
/// کنترلر تنظیمات حسابداری
/// </summary>
[Route("api/[controller]")]
public class AccountingSettingsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر تنظیمات حسابداری
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public AccountingSettingsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تنظیمات حسابداری
    /// </summary>
    /// <returns>تنظیمات حسابداری</returns>
    [HttpGet]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<AccountingSettingsDto>> GetAccountingSettings()
    {
        try
        {
            var settings = await _mediator.Send(new GetAccountingSettingsQuery());
            return Success(settings);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تنظیمات حسابداری");
        }
    }

    /// <summary>
    /// به‌روزرسانی تنظیمات حسابداری
    /// </summary>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> UpdateAccountingSettings([FromBody] UpsertAccountingSettingsCommand command)
    {
        try
        {
            var ok = await _mediator.Send(command);
            if (!ok) return BadRequest("به‌روزرسانی تنظیمات انجام نشد");
            return Success("تنظیمات حسابداری با موفقیت به‌روزرسانی شدند");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی تنظیمات حسابداری");
        }
    }
}
