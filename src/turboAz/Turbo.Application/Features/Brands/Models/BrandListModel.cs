using AutoMapper;
using Core.Persistence.Paging;
using Turbo.Application.Features.Brands.DTOs;
using Turbo.Application.Services.Mapping;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Brands.Models;

public class BrandListModel : BasePageableModel, IMapFrom<IPaginate<Brand>>
{
    public IList<BrandListDto> Items { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
    }
}