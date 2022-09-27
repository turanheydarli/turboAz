using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Turbo.Application.Features.Models.Models;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Models.Queries.GetListModel;

public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Model> models = await _modelRepository.GetListAsync(
            include: m => m.Include(p => p.Brand),
            size: request.PageRequest.PageSize,
            index: request.PageRequest.Page,
            cancellationToken: cancellationToken);

        ModelListModel modelListModel = _mapper.Map<ModelListModel>(models);

        return modelListModel;
    }
}