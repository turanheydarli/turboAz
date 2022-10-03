using AutoMapper;
using Turbo.Application.Services.Mapping;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Categories.DTOs;

public class CategoryGetByIdDto : IMapFrom<Category>
{
    public int Id { get; set; }
    public string Slug { get; set; }
    public int? ParentId { get; set; }
    public string ParentName { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Keywords { get; set; }
    public int CategoryOrder { get; set; }
    public int HomepageOrder { get; set; }
    public bool ShowProductsOnIndex { get; set; }
    public bool IsFeatured { get; set; }
    public int FeaturedOrder { get; set; }
    public bool Visibility { get; set; }
    public bool ShowImageOnNavigation { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, CategoryGetByIdDto>().ForMember(c => c.ParentName, opt =>
        {
            opt.MapFrom(p => p.Parent.Name);
        });
    }
}