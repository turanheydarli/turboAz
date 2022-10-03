using Core.Persistence.Paging;
using Turbo.Application.Features.Categories.DTOs;
using Turbo.Application.Services.Mapping;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Categories.Models;

public class CategoryListModel:BasePageableModel,IMapFrom<IPaginate<Category>>
{
    public IList<CategoryListDto> Items { get; set; }
}