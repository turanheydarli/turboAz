using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Turbo.Application.Features.Brands.Models;

namespace Turbo.Application.Features.Brands.Queries.GetListByDynamicBrand;

public class GetListByDynamicBrandQuery : IRequest<BrandListModel>
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
    
    public GetListByDynamicBrandQuery(PageRequest pageRequest, Dynamic dynamic)
    {
        PageRequest = pageRequest;
        Dynamic = dynamic;
    }

    public GetListByDynamicBrandQuery()
    {
            
    }
}