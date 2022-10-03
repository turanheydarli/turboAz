using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Turbo.Application.Features.Categories.Models;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Categories.Queries.GetListByDynamicCategory;

public class GetListByDynamicCategoryQueryHandler : IRequestHandler<GetListByDynamicCategoryQuery, CategoryListModel>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetListByDynamicCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryListModel> Handle(GetListByDynamicCategoryQuery request,
        CancellationToken cancellationToken)
    {
        IPaginate<Category> categories = await _categoryRepository.GetListByDynamicAsync(dynamic: request.Dynamic,
            size: request.PageRequest.PageSize,
            index: request.PageRequest.Page,
            include: c => c.Include(p => p.Parent), cancellationToken: cancellationToken);

        CategoryListModel categoryListModel = _mapper.Map<CategoryListModel>(categories);

        return categoryListModel;
    }
}