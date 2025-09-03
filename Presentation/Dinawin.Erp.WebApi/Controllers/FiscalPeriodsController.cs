using Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Queries.GetPeriodsByYear;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کنترلر دوره‌های مالی
/// Fiscal periods controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class FiscalPeriodsController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// سازنده کنترلر
    /// Controller constructor
    /// </summary>
    public FiscalPeriodsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// لیست دوره‌های یک سال مالی
    /// Get periods by fiscal year
    /// </summary>
    [HttpGet("byYear/{fiscalYearId}")]
    [ProducesResponseType(typeof(IEnumerable<FiscalPeriodDto>), 200)]
    public async Task<ActionResult<IEnumerable<FiscalPeriodDto>>> GetByYear(Guid fiscalYearId)
    {
        var result = await _mediator.Send(new GetPeriodsByYearQuery(fiscalYearId));
        return Ok(result);
    }
}

using Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Queries.GetPeriodsByYear;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class FiscalPeriodsController : ControllerBase
{
    private readonly IMediator _mediator;
    public FiscalPeriodsController(IMediator mediator) { _mediator = mediator; }

    [HttpGet("by-year/{fiscalYearId}")]
    public async Task<ActionResult<IEnumerable<FiscalPeriodDto>>> GetByYear(Guid fiscalYearId)
    {
        var result = await _mediator.Send(new GetPeriodsByYearQuery(fiscalYearId));
        return Ok(result);
    }
}
