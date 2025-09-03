using Dinawin.Erp.Application.Features.Inventory.Warehouses.Queries.GetAllWarehouses;
using Dinawin.Erp.Application.Features.Inventory.Warehouses.Commands.CreateWarehouse;
using Dinawin.Erp.Application.Features.Inventory.Warehouses.Commands.UpdateWarehouse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کنترلر انبارها
/// Warehouses controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class WarehousesController : ControllerBase
{
	private readonly IMediator _mediator;
	public WarehousesController(IMediator mediator) { _mediator = mediator; }

	/// <summary>
	/// لیست انبارها
	/// Get warehouses
	/// </summary>
	[HttpGet]
	[ProducesResponseType(typeof(IEnumerable<WarehouseListItemDto>), 200)]
	public async Task<ActionResult<IEnumerable<WarehouseListItemDto>>> Get()
	{
		var result = await _mediator.Send(new GetAllWarehousesQuery());
		return Ok(result);
	}

	/// <summary>
	/// ایجاد انبار جدید
	/// Create new warehouse
	/// </summary>
	[HttpPost]
	[ProducesResponseType(typeof(Guid), 201)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateWarehouseCommand command)
	{
		var id = await _mediator.Send(command);
		return CreatedAtAction(nameof(Get), new { id }, id);
	}

	/// <summary>
	/// به‌روزرسانی انبار
	/// Update warehouse
	/// </summary>
	[HttpPut("{id}")]
	[ProducesResponseType(200)]
	public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWarehouseCommand command)
	{
		if (command.Id != id) return BadRequest();
		var ok = await _mediator.Send(command);
		if (!ok) return NotFound();
		return Ok();
	}
}
