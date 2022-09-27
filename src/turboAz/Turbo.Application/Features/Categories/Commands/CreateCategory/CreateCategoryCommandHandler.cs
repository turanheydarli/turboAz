using AutoMapper;
using MediatR;
using Turbo.Application.Features.Categories.DTOs;
using Turbo.Application.Features.Categories.Rules;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;
    
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryBusinessRules.CategoryNameShouldNotBeExisted(request.Name);
        
        Category category = _mapper.Map<Category>(request);
        Category createdCategory = await _categoryRepository.AddAsync(category);
        CreatedCategoryDto createdCategoryDto = _mapper.Map<CreatedCategoryDto>(createdCategory);

        return createdCategoryDto;
    }
}