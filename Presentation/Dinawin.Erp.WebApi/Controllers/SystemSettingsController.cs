using Dinawin.Erp.Application.Features.System.Settings.Queries.GetSettingsByCategory;
using Dinawin.Erp.Application.Features.System.Settings.Commands.UpsertSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SystemSettingsController : ControllerBase
{
    private readonly IMediator _mediator;
    public SystemSettingsController(IMediator mediator) { _mediator = mediator; }

    [HttpGet("category/{category}")]
    public async Task<ActionResult<IEnumerable<SystemSettingDto>>> GetByCategory(
        string category, 
        [FromQuery] string businessId = "default")
    {
        var result = await _mediator.Send(new GetSettingsByCategoryQuery(category, businessId));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert([FromBody] UpsertSettingCommand command)
    {
        var ok = await _mediator.Send(command);
        if (!ok) return BadRequest();
        return Ok();
    }
}
