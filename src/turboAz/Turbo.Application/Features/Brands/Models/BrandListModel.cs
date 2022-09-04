using AutoMapper;
using Core.Persistence.Paging;
using Turbo.Application.Features.Brands.Dtos;
using Turbo.Application.Services.Mapping;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Brands.Models;

public class BrandListModel : IMapFrom<IPaginate<Brand>>
{
    public IList<BrandDto> Items { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
    }
}