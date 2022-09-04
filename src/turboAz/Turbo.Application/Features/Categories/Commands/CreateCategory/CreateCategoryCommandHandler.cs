using AutoMapper;
using MediatR;
using Turbo.Application.Features.Categories.Dtos;
using Turbo.Application.Services.Repositories;
using Turbo.Application.Services.Slug;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);

        category.Slug = SlugHelper.Create(request.Name);
        
        var addedCategory = await _categoryRepository.AddAsync(category);

        return _mapper.Map<CreatedCategoryDto>(addedCategory);
    }
}