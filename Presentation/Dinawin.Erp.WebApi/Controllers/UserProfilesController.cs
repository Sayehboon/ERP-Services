using Dinawin.Erp.Application.Features.Users.UserProfiles.Queries.GetUserProfileById;
using Dinawin.Erp.Application.Features.Users.UserProfiles.Queries.Dtos;
using Dinawin.Erp.Application.Features.Users.UserProfiles.Commands.UpdateUserProfile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UserProfilesController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserProfilesController(IMediator mediator) { _mediator = mediator; }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserProfileDto>> Get(Guid id)
    {
        var result = await _mediator.Send(new GetUserProfileByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserProfileCommand command)
    {
        if (command.Id != id) return BadRequest();
        var ok = await _mediator.Send(command);
        if (!ok) return NotFound();
        return Ok();
    }
}
