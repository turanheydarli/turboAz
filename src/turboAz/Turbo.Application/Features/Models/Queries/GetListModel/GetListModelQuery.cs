using Core.Application.Requests;
using MediatR;
using Turbo.Application.Features.Models.Models;

namespace Turbo.Application.Features.Models.Queries.GetListModel;

public class GetListModelQuery : IRequest<ModelListModel>
{
    public PageRequest PageRequest { get; set; }

    public GetListModelQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public GetListModelQuery()
    {
        
    }
}