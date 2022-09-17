using Core.CrossCuttingConcers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Turbo.Application.Features.Models.Commands.CreateModel;
using Turbo.Application.Features.Models.Commands.UpdateModel;
using Turbo.Application.Features.Models.DTOs;

namespace Turbo.WebAPI.Controllers.v1;

[Route("api/v1/[controller]")]
public class ModelsController : BaseController
{
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreatedModelDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpPost]
    public async Task<IActionResult> CreateModel([FromBody] CreateModelCommand createModelCommand)
    {
        CreatedModelDto createdModelDto = await Mediator.Send(createModelCommand);

        return Ok(createdModelDto);
    }
    
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdatedModelDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpPut]
    public async Task<IActionResult> UpdateModel([FromBody] UpdateModelCommand updateModelCommand)
    {
        UpdatedModelDto updatedModelDto = await Mediator.Send(updateModelCommand);

        return Ok(updatedModelDto);
    }
}