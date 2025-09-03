using Dinawin.Erp.Application.Features.Inventory.Movements.Queries.GetMovementsByProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کنترلر حرکات انبار
/// Inventory movements controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class InventoryMovementsController : ControllerBase
{
	private readonly IMediator _mediator;
	public InventoryMovementsController(IMediator mediator) { _mediator = mediator; }

	/// <summary>
	/// دریافت حرکات انبار برای یک کالا
	/// Get movements by product id
	/// </summary>
	[HttpGet]
	public async Task<ActionResult<IEnumerable<InventoryMovementDto>>> Get([FromQuery] Guid productId)
	{
		var result = await _mediator.Send(new GetMovementsByProductQuery(productId));
		return Ok(result);
	}
}
