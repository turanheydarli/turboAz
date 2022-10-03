using AutoMapper;
using MediatR;
using Turbo.Application.Features.Categories.Rules;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _categoryRepository.GetAsync(c => c.Id == request.Id);
        
        _categoryBusinessRules.CategoryShouldExistWhenRequested(category);

        await _categoryRepository.DeleteAsync(category);
        
        return  Unit.Value;
    }
}