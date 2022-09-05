using Core.Application.Requests;
using Core.CrossCuttingConcers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Turbo.Application.Features.Brands.Commands.CreateBrand;
using Turbo.Application.Features.Brands.Commands.DeleteBrand;
using Turbo.Application.Features.Brands.Commands.UpdateBrand;
using Turbo.Application.Features.Brands.DTOs;
using Turbo.Application.Features.Brands.Models;
using Turbo.Application.Features.Brands.Queries.GetByIdBrand;
using Turbo.Application.Features.Brands.Queries.GetListBrand;

namespace Turbo.WebAPI.Controllers.v1;

[Route("api/v1/[controller]")]
public class BrandsController : BaseController
{
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BrandListModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpGet]
    public async Task<IActionResult> GetAllBrands([FromQuery] PageRequest pageRequest)
    {
        GetListBrandQuery getListBrandQuery = new GetListBrandQuery(pageRequest);

        BrandListModel brandListModel = await Mediator.Send(getListBrandQuery);

        return Ok(brandListModel);
    }

    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BrandGetByIdDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetBrandById([FromRoute] GetByIdBrandQuery getByIdBrandQuery)
    {
        BrandGetByIdDto brandGetByIdDto = await Mediator.Send(getByIdBrandQuery);

        return Ok(brandGetByIdDto);
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreatedBrandDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpPost]
    public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommand createBrandCommand)
    {
        CreatedBrandDto createdBrandDto = await Mediator.Send(createBrandCommand);

        return Ok(createdBrandDto);
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdatedBrandDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpPut]
    public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommand updateBrandCommand)
    {
        UpdatedBrandDto updatedBrandDto = await Mediator.Send(updateBrandCommand);

        return Ok(updatedBrandDto);
    }

    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdatedBrandDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BusinessProblemDetails))]
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteBrand([FromRoute] DeleteBrandCommand deleteBrandCommand)
    {
        await Mediator.Send(deleteBrandCommand);

        return Ok();
    }
}