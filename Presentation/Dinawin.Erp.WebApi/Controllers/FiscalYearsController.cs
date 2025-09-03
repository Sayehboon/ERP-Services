using Dinawin.Erp.Application.Features.Accounting.FiscalYears.Queries.GetAllFiscalYears;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class FiscalYearsController : ControllerBase
{
    private readonly IMediator _mediator;
    public FiscalYearsController(IMediator mediator) { _mediator = mediator; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FiscalYearDto>>> Get()
    {
        var result = await _mediator.Send(new GetAllFiscalYearsQuery());
        return Ok(result);
    }
}
