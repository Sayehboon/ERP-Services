using Dinawin.Erp.Application.Features.Treasury.CashBoxes.Queries.Dtos;
using Dinawin.Erp.Application.Features.Treasury.CashBoxes.Queries.GetCashBoxesByBusiness;
using Dinawin.Erp.Application.Features.Treasury.CashBoxes.Commands.CreateCashBox;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CashBoxesController : ControllerBase
{
    private readonly IMediator _mediator;
    public CashBoxesController(IMediator mediator) { _mediator = mediator; }

    [HttpGet("business/{businessId}")]
    [ProducesResponseType(typeof(IEnumerable<CashBoxDto>), 200)]
    public async Task<ActionResult<IEnumerable<CashBoxDto>>> GetByBusiness(string businessId)
    {
        var result = await _mediator.Send(new GetCashBoxesByBusinessQuery(businessId));
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateCashBoxCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetByBusiness), new { businessId = command.BusinessId }, id);
    }
}
