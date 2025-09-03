using Dinawin.Erp.Application.Features.Treasury.CashTransactions.Queries.Dtos;
using Dinawin.Erp.Application.Features.Treasury.CashTransactions.Queries.GetCashTransactionsByCashBoxes;
using Dinawin.Erp.Application.Features.Treasury.CashTransactions.Commands.CreateCashTransaction;
using Dinawin.Erp.Application.Features.Treasury.CashTransactions.Commands.PostCashTransaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CashTransactionsController : ControllerBase
{
    private readonly IMediator _mediator;
    public CashTransactionsController(IMediator mediator) { _mediator = mediator; }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CashTransactionDto>), 200)]
    public async Task<ActionResult<IEnumerable<CashTransactionDto>>> Get([FromQuery] Guid[] cashBoxIds)
    {
        var result = await _mediator.Send(new GetCashTransactionsByCashBoxesQuery(cashBoxIds));
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateCashTransactionCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { cashBoxIds = new[] { command.CashBoxId } }, id);
    }

    [HttpPost("{id}/post")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Post(Guid id)
    {
        var ok = await _mediator.Send(new PostCashTransactionCommand(id));
        if (!ok) return NotFound();
        return Ok();
    }
}
