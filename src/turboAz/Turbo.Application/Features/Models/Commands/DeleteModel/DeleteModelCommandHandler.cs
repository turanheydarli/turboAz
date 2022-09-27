using MediatR;
using Turbo.Application.Features.Models.Rules;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Models.Commands.DeleteModel;

public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand>
{
    private readonly IModelRepository _modelRepository;
    private readonly ModelBusinessRules _modelBusinessRules;

    public DeleteModelCommandHandler(IModelRepository modelRepository, ModelBusinessRules modelBusinessRules)
    {
        _modelRepository = modelRepository;
        _modelBusinessRules = modelBusinessRules;
    }

    public async Task<Unit> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        Model model = await _modelRepository.GetAsync(m => m.Id == request.Id);

        _modelBusinessRules.ModelShouldExistWhenRequested(model);

        await _modelRepository.DeleteAsync(model);

        return new Unit();
    }
}