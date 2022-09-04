using AutoMapper;
using Turbo.Application.Services.Mapping;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Brands.Dtos;

public class UpdatedBrandDto : IMapFrom<Brand>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Brand, UpdatedBrandDto>().ReverseMap();
    }
}