using Core.Application.Requests;
using MediatR;
using Turbo.Application.Features.Categories.Models;

namespace Turbo.Application.Features.Categories.Queries.GetListCategory;

public class GetListCategoryQuery : IRequest<CategoryListModel>
{
    public GetListCategoryQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public GetListCategoryQuery()
    {
    }

    public PageRequest PageRequest { get; set; }
}