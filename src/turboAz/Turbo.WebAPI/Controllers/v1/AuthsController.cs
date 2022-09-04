using Microsoft.AspNetCore.Mvc;
using Turbo.Application.Features.Authorizations.Commands;
using Turbo.Application.Features.Authorizations.Dtos;
using Turbo.Application.Features.Authorizations.Queries;

namespace Turbo.WebAPI.Controllers.v1;

[Route("api/v1/[controller]")]
public class AuthsController : BaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
    {
        RegisteredDto registeredDto = await Mediator.Send(registerCommand);
        return Created("", registeredDto.AccessToken);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery loginQuery)
    {
        return Ok(await Mediator.Send(loginQuery));
    }
}