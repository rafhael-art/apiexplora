using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xplora.UseCases.UseCases.User.Commands.Insert;
using Xplora.UseCases.UseCases.User.Commands.Update;
using Xplora.UseCases.UseCases.User.Queries.GetByEmail;
using Xplora.UseCases.UseCases.User.Queries.Login;

namespace Xplora.Api.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class UserController : ControllerBase
  {
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost("Register")]
    public async Task<ActionResult> Register([FromBody] UserInsertCommand command)
    {
      var resp = await _mediator.Send(command);
      return Ok(resp);
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login([FromBody] UserLoginQuery query)
    {
      var resp = await _mediator.Send(query);
      return Ok(resp);
    }

    [HttpPut("Edit")]
    public async Task<ActionResult> Edit([FromBody] UserUpdateCommand command)
    {
      var resp = await _mediator.Send(command);
      return Ok(resp);
    }

    [HttpGet("ValidateEmail")]
    public async Task<ActionResult> ValidateEmail([FromQuery] UserGetByEmailQuery query)
    {
      var resp = await _mediator.Send(query);
      return Ok(resp);
    }
  }
}

