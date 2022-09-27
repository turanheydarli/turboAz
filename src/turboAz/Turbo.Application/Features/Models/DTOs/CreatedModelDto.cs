using AutoMapper;
using Turbo.Application.Services.Mapping;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Models.DTOs;

public class CreatedModelDto : IMapFrom<Model>
{
    public int Id { get; set; }
    public string BrandName { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Model, CreatedModelDto>()
            .ForMember(m => m.BrandName, 
                opt => opt.MapFrom(p => p.Brand.Name));
    }
}