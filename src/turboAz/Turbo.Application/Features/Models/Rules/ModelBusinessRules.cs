using Core.CrossCuttingConcers.Exceptions;
using Turbo.Application.Features.Models.Constants;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Models.Rules;

public class ModelBusinessRules
{
    private IModelRepository _modelRepository;

    public ModelBusinessRules(IModelRepository modelRepository)
    {
        _modelRepository = modelRepository;
    }

    public void ModelShouldExistWhenRequested(Model model)
    {
        if (model == null) throw new BusinessException(ModelMessages.ModelDoesNotExist);
    }
    
    public async Task ModelShouldExistWhenRequested(int modelId)
    {
        Model result = await _modelRepository.GetAsync(m => m.Id == modelId);
        if (result == null) throw new BusinessException(ModelMessages.ModelDoesNotExist);
    }
}