using Dinawin.Erp.Application.Features.Accounting.Settings.Queries.GetAccountingSettings;
using Dinawin.Erp.Application.Features.Accounting.Settings.Commands.UpsertAccountingSettings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کنترلر تنظیمات حسابداری
/// Accounting settings controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AccountingSettingsController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountingSettingsController(IMediator mediator) { _mediator = mediator; }

    /// <summary>
    /// دریافت تنظیمات حسابداری
    /// Get accounting settings
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(AccountingSettingsDto), 200)]
    public async Task<ActionResult<AccountingSettingsDto>> Get([FromQuery] string businessId = "default")
    {
        var dto = await _mediator.Send(new GetAccountingSettingsQuery(businessId));
        return Ok(dto);
    }

    /// <summary>
    /// ذخیره/به‌روزرسانی تنظیمات حسابداری
    /// Upsert accounting settings
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Upsert([FromBody] UpsertAccountingSettingsCommand command)
    {
        var ok = await _mediator.Send(command);
        if (!ok) return BadRequest();
        return Ok();
    }
}


