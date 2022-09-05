using Core.CrossCuttingConcers.Exceptions;
using Turbo.Application.Features.Categories.Common;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Categories.Rules;

public class CategoryRules
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void CategoryShouldExistWhenRequested(Category category)
    {
        if (category == null) throw new BusinessException(CategoryMessages.CategoryDoesNotExist);
    }
    public async Task CategoryNameShouldNotBeExisted(string categoryName)
    {
        Category result = await _categoryRepository.GetAsync(b => b.Name == categoryName);
        if (result != null) throw new BusinessException(CategoryMessages.CategoryNameExist);
    }
}