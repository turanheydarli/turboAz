using AutoMapper;
using MediatR;
using Turbo.Application.Features.Brands.Rules;
using Turbo.Application.Features.Models.DTOs;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Models.Commands.CreateModel;

public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelDto>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    private readonly BrandBusinessRules _brandBusinessRules;

    public CreateModelCommandHandler(IMapper mapper, IModelRepository modelRepository, BrandBusinessRules brandBusinessRules)
    {
        _mapper = mapper;
        _modelRepository = modelRepository;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<CreatedModelDto> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {

        await _brandBusinessRules.BrandShouldExistWhenRequested(request.BrandId);
        
        Model model = _mapper.Map<Model>(request);
        Model createdModel = await _modelRepository.AddAsync(model);
        CreatedModelDto createdModelDto = _mapper.Map<CreatedModelDto>(createdModel);

        return createdModelDto;
    }
}