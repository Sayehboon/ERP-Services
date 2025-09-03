using Dinawin.Erp.Application.Features.Accounting.Vendors.Queries.GetAllVendors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class VendorsController : ControllerBase
{
	private readonly IMediator _mediator;
	public VendorsController(IMediator mediator) { _mediator = mediator; }

	[HttpGet]
	public async Task<ActionResult<IEnumerable<VendorDto>>> Get([FromQuery] string? keyword = null)
	{
		var result = await _mediator.Send(new GetAllVendorsQuery(keyword));
		return Ok(result);
	}
}
