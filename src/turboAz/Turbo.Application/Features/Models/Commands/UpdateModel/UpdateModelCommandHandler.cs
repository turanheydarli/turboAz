using AutoMapper;
using MediatR;
using Turbo.Application.Features.Models.DTOs;
using Turbo.Application.Features.Models.Rules;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Models.Commands.UpdateModel;

public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, UpdatedModelDto>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    private readonly ModelBusinessRules _modelBusinessRules;
    
    public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
        _modelBusinessRules = modelBusinessRules;
    }

    public async Task<UpdatedModelDto> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        Model model = await _modelRepository.GetAsync(m => m.Id == request.Id);

        _modelBusinessRules.ModelShouldExistWhenRequested(model);

        model.Name = request.Name;
        model.Updated = DateTime.UtcNow;

        await _modelRepository.UpdateAsync(model);

        UpdatedModelDto updatedModelDto = _mapper.Map<UpdatedModelDto>(model);

        return updatedModelDto;
    }
}