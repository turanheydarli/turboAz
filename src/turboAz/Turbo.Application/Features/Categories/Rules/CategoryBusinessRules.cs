using Core.CrossCuttingConcers.Exceptions;
using Turbo.Application.Features.Categories.Constants;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Categories.Rules;

public class CategoryBusinessRules
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task CategoryNameShouldNotBeExisted(string categoryName)
    {
        Category result = await _categoryRepository.GetAsync(b => b.Name == categoryName);
        if (result != null) throw new BusinessException(CategoryMessages.CategoryNameExist);
    }
}