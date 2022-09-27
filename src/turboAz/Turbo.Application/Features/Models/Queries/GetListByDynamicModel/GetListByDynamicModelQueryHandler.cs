using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Turbo.Application.Features.Models.Models;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Models.Queries.GetListByDynamicModel;

public class GetListByDynamicModelQueryHandler : IRequestHandler<GetListByDynamicModelQuery, ModelListModel>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListByDynamicModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<ModelListModel> Handle(GetListByDynamicModelQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync(
            dynamic: request.Dynamic,
            size: request.PageRequest.PageSize,
            index: request.PageRequest.Page,
            include: m => m.Include(p => p.Brand), 
            cancellationToken: cancellationToken);

        ModelListModel modelListModel = _mapper.Map<ModelListModel>(models);

        return modelListModel;
    }
}