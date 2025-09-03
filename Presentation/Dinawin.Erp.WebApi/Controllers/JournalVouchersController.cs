using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Queries.GetAllJournalVouchers;
using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Queries.Dtos;
using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Commands.CreateJournalVoucher;
using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Commands.UpdateJournalVoucher;
using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Commands.PostJournalVoucher;
using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Commands.DeleteJournalVoucher;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class JournalVouchersController : ControllerBase
{
    private readonly IMediator _mediator;
    public JournalVouchersController(IMediator mediator) { _mediator = mediator; }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<JournalVoucherDto>), 200)]
    public async Task<ActionResult<IEnumerable<JournalVoucherDto>>> Get(
        [FromQuery] string? status = null,
        [FromQuery] string? type = null,
        [FromQuery] string? number = null,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] string? sortBy = "seq_no")
    {
        var result = await _mediator.Send(new GetAllJournalVouchersQuery(status, type, number, fromDate, toDate, sortBy));
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateJournalVoucherCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateJournalVoucherCommand command)
    {
        if (command.Id != id) return BadRequest();
        var ok = await _mediator.Send(command);
        if (!ok) return NotFound();
        return Ok();
    }

    [HttpPost("{id}/post")]
    public async Task<IActionResult> Post(Guid id)
    {
        var ok = await _mediator.Send(new PostJournalVoucherCommand(id));
        if (!ok) return NotFound();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var ok = await _mediator.Send(new DeleteJournalVoucherCommand(id));
        if (!ok) return NotFound();
        return NoContent();
    }
}
