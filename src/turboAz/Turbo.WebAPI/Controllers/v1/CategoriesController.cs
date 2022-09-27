using Core.CrossCuttingConcers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Turbo.Application.Features.Categories.Commands.CreateCategory;
using Turbo.Application.Features.Categories.DTOs;

namespace Turbo.WebAPI.Controllers.v1;

[Route("api/v1/[controller]")]
public class CategoriesController : BaseController
{
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreatedCategoryDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        CreatedCategoryDto createdCategoryDto = await Mediator.Send(createCategoryCommand);

        return Ok(createdCategoryDto);
    }
}