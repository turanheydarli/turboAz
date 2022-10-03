using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Turbo.Application.Features.Categories.Models;

namespace Turbo.Application.Features.Categories.Queries.GetListByDynamicCategory;

public class GetListByDynamicCategoryQuery : IRequest<CategoryListModel>
{
    public GetListByDynamicCategoryQuery(PageRequest pageRequest, Dynamic dynamic)
    {
        PageRequest = pageRequest;
        Dynamic = dynamic;
    }

    public GetListByDynamicCategoryQuery()
    {
    }

    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
}