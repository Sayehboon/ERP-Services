using Dinawin.Erp.Application.Features.Inventory.Bins.Queries.GetBinsByWarehouse;
using Dinawin.Erp.Application.Features.Inventory.Bins.Commands.CreateBin;
using Dinawin.Erp.Application.Features.Inventory.Bins.Commands.UpdateBin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BinsController : ControllerBase
{
    private readonly IMediator _mediator;
    public BinsController(IMediator mediator) { _mediator = mediator; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BinDto>>> Get([FromQuery] Guid? warehouseId = null)
    {
        var result = await _mediator.Send(new GetBinsByWarehouseQuery(warehouseId));
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateBinCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBinCommand command)
    {
        if (command.Id != id) return BadRequest();
        var ok = await _mediator.Send(command);
        if (!ok) return NotFound();
        return Ok();
    }
}
