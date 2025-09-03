using Dinawin.Erp.Application.Features.Users.Companies.Queries.GetAllCompanies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CompaniesController : ControllerBase
{
    private readonly IMediator _mediator;
    public CompaniesController(IMediator mediator) { _mediator = mediator; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyDto>>> Get()
    {
        var result = await _mediator.Send(new GetAllCompaniesQuery());
        return Ok(result);
    }
}
