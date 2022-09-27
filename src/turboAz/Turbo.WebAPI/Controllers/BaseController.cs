using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Turbo.WebAPI.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    private IMediator _mediator;
}