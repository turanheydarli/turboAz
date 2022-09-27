using Core.Application.Requests;
using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Turbo.Application.Features.Models.Commands.CreateModel;
using Turbo.Application.Features.Models.Commands.DeleteModel;
using Turbo.Application.Features.Models.Commands.UpdateModel;
using Turbo.Application.Features.Models.DTOs;
using Turbo.Application.Features.Models.Models;
using Turbo.Application.Features.Models.Queries.GetByIdModel;
using Turbo.Application.Features.Models.Queries.GetListByDynamicModel;
using Turbo.Application.Features.Models.Queries.GetListModel;

namespace Turbo.WebAPI.Controllers.v1;

[Route("api/v1/[controller]")]
public class ModelsController : BaseController
{
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ModelListModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpGet]
    public async Task<IActionResult> GetAllModels([FromQuery] PageRequest pageRequest)
    {
        GetListModelQuery getListModelQuery = new GetListModelQuery(pageRequest);

        ModelListModel modelListModel = await Mediator.Send(getListModelQuery);

        return Ok(modelListModel);
    }
    
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ModelListModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpPost("get-by-dynamic")]
    public async Task<IActionResult> GetAllModelsByDynamic([FromQuery] PageRequest pageRequest,
        [FromBody] Dynamic dynamic)
    {
        GetListByDynamicModelQuery getListByDynamicModelQuery = new GetListByDynamicModelQuery(pageRequest, dynamic);

        ModelListModel modelListModel = await Mediator.Send(getListByDynamicModelQuery);

        return Ok(modelListModel);
    }
    
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ModelGetByIdDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetModelById([FromRoute] GetByIdModelQuery getByIdModelQuery)
    {
        ModelGetByIdDto modelGetByIdDto = await Mediator.Send(getByIdModelQuery);

        return Ok(modelGetByIdDto);
    }
    
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
    
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteModel([FromRoute] DeleteModelCommand deleteModelCommand)
    {
        await Mediator.Send(deleteModelCommand);

        return Ok();
    }
}