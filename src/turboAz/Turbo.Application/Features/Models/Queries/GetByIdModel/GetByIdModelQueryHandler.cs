using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Turbo.Application.Features.Models.DTOs;
using Turbo.Application.Features.Models.Rules;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Models.Queries.GetByIdModel;

public class GetByIdModelQueryHandler : IRequestHandler<GetByIdModelQuery, ModelGetByIdDto>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    private readonly ModelBusinessRules _modelBusinessRules;

    public GetByIdModelQueryHandler(IModelRepository modelRepository, IMapper mapper,
        ModelBusinessRules modelBusinessRules)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
        _modelBusinessRules = modelBusinessRules;
    }

    public async Task<ModelGetByIdDto> Handle(GetByIdModelQuery request, CancellationToken cancellationToken)
    {
        Model model = await _modelRepository.GetAsync(
            predicate: m => m.Id == request.Id,
            include: m => m.Include(p => p.Brand));

        _modelBusinessRules.ModelShouldExistWhenRequested(model);

        ModelGetByIdDto modelGetByIdDto = _mapper.Map<ModelGetByIdDto>(model);

        return modelGetByIdDto;
    }
}