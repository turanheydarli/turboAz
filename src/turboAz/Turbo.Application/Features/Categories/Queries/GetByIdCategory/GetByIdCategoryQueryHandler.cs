using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Turbo.Application.Features.Categories.DTOs;
using Turbo.Application.Features.Categories.Rules;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryGetByIdDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper,
        CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<CategoryGetByIdDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
    {
        Category category = await _categoryRepository.GetAsync(
            predicate: c => c.Id == request.Id,
            include: c => c.Include(p => p.Parent));

        _categoryBusinessRules.CategoryShouldExistWhenRequested(category);

        CategoryGetByIdDto categoryGetByIdDto = _mapper.Map<CategoryGetByIdDto>(category);

        return categoryGetByIdDto;
    }
}