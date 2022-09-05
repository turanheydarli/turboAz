using Core.Application.Requests;
using MediatR;
using Turbo.Application.Features.Brands.Models;

namespace Turbo.Application.Features.Brands.Queries.GetListBrand;

public class GetListBrandQuery : IRequest<BrandListModel>
{
    public GetListBrandQuery()
    {
    }

    public GetListBrandQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public PageRequest PageRequest { get; set; }
}