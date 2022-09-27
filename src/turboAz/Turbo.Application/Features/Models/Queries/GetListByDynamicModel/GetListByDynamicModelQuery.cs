using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Turbo.Application.Features.Models.Models;

namespace Turbo.Application.Features.Models.Queries.GetListByDynamicModel;

public class GetListByDynamicModelQuery : IRequest<ModelListModel>
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
    
    public GetListByDynamicModelQuery(PageRequest pageRequest, Dynamic dynamic)
    {
        PageRequest = pageRequest;
        Dynamic = dynamic;
    }

    public GetListByDynamicModelQuery()
    {
        
    }
}