using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Turbo.Application.Features.Brands.DTOs;
using Turbo.Domain.Entities.Catalog;
using Turbo.Application.Services.Mapping;

namespace Turbo.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommand : IMapFrom<Brand>, IRequest<CreatedBrandDto>, ISecuredRequest
{
    public string Name { get; set; }
    public string[] Roles => new[] { "brand.add" };

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Brand, CreateBrandCommand>().ReverseMap();
    }
}