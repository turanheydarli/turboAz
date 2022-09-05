using AutoMapper;
using MediatR;
using Turbo.Application.Features.Categories.DTOs;
using Turbo.Application.Features.Categories.Rules;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryRules _categoryRules;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryRules categoryRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryRules = categoryRules;
    }

    public async Task<UpdatedCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _categoryRepository.GetAsync(c => c.Id == request.Id);
        
        _categoryRules.CategoryShouldExistWhenRequested(category);

        category.Description = request.Description;
        category.Keywords = request.Keywords;
        category.Name = request.Name;
        category.ParentId = request.ParentId;
        category.Title = request.Title;
        category.Visibility = request.Visibility;
        category.CategoryOrder = request.CategoryOrder;
        category.FeaturedOrder = request.FeaturedOrder;
        category.HomepageOrder = request.HomepageOrder;
        category.IsFeatured = request.IsFeatured;
        category.ShowImageOnNavigation = request.ShowImageOnNavigation;
        category.ShowProductsOnIndex = request.ShowProductsOnIndex;
        
        category.UpdatedTime = DateTime.UtcNow;

        Category updatedCategory = await _categoryRepository.UpdateAsync(category);

        UpdatedCategoryDto updatedCategoryDto = _mapper.Map<UpdatedCategoryDto>(updatedCategory);

        return updatedCategoryDto;
    }
}