using Dinawin.Erp.Application.Features.Treasury.BankAccounts.Queries.Dtos;
using Dinawin.Erp.Application.Features.Treasury.BankAccounts.Queries.GetBankAccountsByBusiness;
using Dinawin.Erp.Application.Features.Treasury.BankAccounts.Commands.CreateBankAccount;
using Dinawin.Erp.Application.Features.Treasury.BankAccounts.Commands.UpdateBankAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BankAccountsController : ControllerBase
{
    private readonly IMediator _mediator;
    public BankAccountsController(IMediator mediator) { _mediator = mediator; }

    [HttpGet("business/{businessId}")]
    [ProducesResponseType(typeof(IEnumerable<BankAccountDto>), 200)]
    public async Task<ActionResult<IEnumerable<BankAccountDto>>> GetByBusiness(string businessId)
    {
        var result = await _mediator.Send(new GetBankAccountsByBusinessQuery(businessId));
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateBankAccountCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetByBusiness), new { businessId = command.BusinessId }, id);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBankAccountCommand command)
    {
        if (command.Id != id) return BadRequest();
        var ok = await _mediator.Send(command);
        if (!ok) return NotFound();
        return Ok();
    }
}
