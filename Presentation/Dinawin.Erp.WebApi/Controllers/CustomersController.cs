using Dinawin.Erp.Application.Features.Accounting.Customers.Queries.Dtos;
using Dinawin.Erp.Application.Features.Accounting.Customers.Queries.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کنترلر مشتریان دریافتنی (AR)
/// AR Customers controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CustomersController : ControllerBase
{
	private readonly IMediator _mediator;

	/// <summary>
	/// سازنده کنترلر
	/// Controller constructor
	/// </summary>
	public CustomersController(IMediator mediator)
	{
		_mediator = mediator;
	}

	/// <summary>
	/// لیست مشتریان فعال
	/// Get active customers
	/// </summary>
	[HttpGet]
	[ProducesResponseType(typeof(IEnumerable<CustomerDto>), 200)]
	public async Task<ActionResult<IEnumerable<CustomerDto>>> Get([FromQuery] string? keyword = null)
	{
		var result = await _mediator.Send(new GetAllCustomersQuery(keyword));
		return Ok(result);
	}
}
