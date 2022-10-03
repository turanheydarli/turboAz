using Core.Application.Requests;
using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Turbo.Application.Features.Categories.Commands.CreateCategory;
using Turbo.Application.Features.Categories.DTOs;
using Turbo.Application.Features.Categories.Models;
using Turbo.Application.Features.Categories.Queries.GetByIdCategory;
using Turbo.Application.Features.Categories.Queries.GetListByDynamicCategory;
using Turbo.Application.Features.Categories.Queries.GetListCategory;

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
    
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryListModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpGet]
    public async Task<IActionResult> GetAllCategories([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryQuery getListCategoryQuery = new GetListCategoryQuery(pageRequest);

        CategoryListModel categoryListModel = await Mediator.Send(getListCategoryQuery);

        return Ok(categoryListModel);
    }
    
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryGetByIdDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] GetByIdCategoryQuery getByIdCategoryQuery)
    {
        CategoryGetByIdDto categoryGetByIdDto = await Mediator.Send(getByIdCategoryQuery);

        return Ok(categoryGetByIdDto);
    }
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryListModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpPost("get-by-dynamic")]
    public async Task<IActionResult> GetAllCategoriesByDynamic([FromQuery] PageRequest pageRequest,
        [FromBody] Dynamic dynamic)
    {
        GetListByDynamicCategoryQuery listByDynamicCategoryQuery = new GetListByDynamicCategoryQuery(pageRequest, dynamic);

        CategoryListModel categoryListModel = await Mediator.Send(listByDynamicCategoryQuery);

        return Ok(categoryListModel);
    }
}