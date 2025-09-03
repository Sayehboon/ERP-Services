using Dinawin.Erp.Application.Features.Accounting.Bills.Queries.GetAllBills;
using Dinawin.Erp.Application.Features.Accounting.Bills.Queries.Dtos;
using Dinawin.Erp.Application.Features.Accounting.Bills.Commands.CreatePurchaseBill;
using Dinawin.Erp.Application.Features.Accounting.Bills.Commands.UpdatePurchaseBill;
using Dinawin.Erp.Application.Features.Accounting.Bills.Commands.PostPurchaseBill;
using Dinawin.Erp.Application.Features.Accounting.Bills.Commands.DeletePurchaseBill;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class PurchaseBillsController : ControllerBase
{
	private readonly IMediator _mediator;
	public PurchaseBillsController(IMediator mediator) { _mediator = mediator; }

	[HttpGet]
	[ProducesResponseType(typeof(IEnumerable<PurchaseBillDto>), 200)]
	public async Task<ActionResult<IEnumerable<PurchaseBillDto>>> Get([FromQuery] Guid? vendorId = null, [FromQuery] string? status = null, [FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
	{
		var result = await _mediator.Send(new GetAllBillsQuery(vendorId, status, fromDate, toDate));
		return Ok(result);
	}

	[HttpPost]
	public async Task<ActionResult<Guid>> Create([FromBody] CreatePurchaseBillCommand command)
	{
		var id = await _mediator.Send(command);
		return CreatedAtAction(nameof(Get), new { id }, id);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePurchaseBillCommand command)
	{
		if (command.Id != id) return BadRequest();
		var ok = await _mediator.Send(command);
		if (!ok) return NotFound();
		return Ok();
	}

	[HttpPost("{id}/post")]
	public async Task<IActionResult> Post(Guid id)
	{
		var ok = await _mediator.Send(new PostPurchaseBillCommand(id));
		if (!ok) return NotFound();
		return Ok();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var ok = await _mediator.Send(new DeletePurchaseBillCommand(id));
		if (!ok) return NotFound();
		return NoContent();
	}
}
