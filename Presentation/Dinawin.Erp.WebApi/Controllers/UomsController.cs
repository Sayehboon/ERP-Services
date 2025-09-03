using Dinawin.Erp.Application.Features.Products.Uoms.Queries.GetAllUoms;
using Dinawin.Erp.Application.Features.Products.Uoms.Commands.UpsertUom;
using Dinawin.Erp.Application.Features.Products.Uoms.Commands.DeleteUom;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کنترلر واحدهای اندازه‌گیری
/// UOMs controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UomsController : ControllerBase
{
	private readonly IMediator _mediator;
	public UomsController(IMediator mediator) { _mediator = mediator; }

	/// <summary>
	/// لیست واحدها
	/// Get UOMs
	/// </summary>
	[HttpGet]
	public async Task<ActionResult<IEnumerable<UomDto>>> Get([FromQuery] string? type = null)
	{
		var result = await _mediator.Send(new GetAllUomsQuery(type));
		return Ok(result);
	}

	[HttpPost]
	public async Task<ActionResult<Guid>> Create([FromBody] UpsertUomCommand command)
	{
		if (command.Id != null) return BadRequest();
		var id = await _mediator.Send(command);
		return CreatedAtAction(nameof(Get), new { id }, id);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(Guid id, [FromBody] UpsertUomCommand command)
	{
		if (command.Id != id) return BadRequest();
		await _mediator.Send(command);
		return Ok();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var ok = await _mediator.Send(new DeleteUomCommand(id));
		if (!ok) return NotFound();
		return NoContent();
	}
}
