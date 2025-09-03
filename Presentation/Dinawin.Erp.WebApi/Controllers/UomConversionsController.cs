using Dinawin.Erp.Application.Features.Products.Uoms.Conversions.Queries.GetConversions;
using Dinawin.Erp.Application.Features.Products.Uoms.Conversions.Commands.UpsertUomConversion;
using Dinawin.Erp.Application.Features.Products.Uoms.Conversions.Commands.DeleteUomConversion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UomConversionsController : ControllerBase
{
	private readonly IMediator _mediator;
	public UomConversionsController(IMediator mediator) { _mediator = mediator; }

	[HttpGet]
	public async Task<ActionResult<IEnumerable<UomConversionDto>>> Get()
	{
		var result = await _mediator.Send(new GetUomConversionsQuery());
		return Ok(result);
	}

	[HttpPost]
	public async Task<ActionResult<Guid>> Create([FromBody] UpsertUomConversionCommand command)
	{
		if (command.Id != null) return BadRequest();
		var id = await _mediator.Send(command);
		return CreatedAtAction(nameof(Get), new { id }, id);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(Guid id, [FromBody] UpsertUomConversionCommand command)
	{
		if (command.Id != id) return BadRequest();
		await _mediator.Send(command);
		return Ok();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var ok = await _mediator.Send(new DeleteUomConversionCommand(id));
		if (!ok) return NotFound();
		return NoContent();
	}
}
