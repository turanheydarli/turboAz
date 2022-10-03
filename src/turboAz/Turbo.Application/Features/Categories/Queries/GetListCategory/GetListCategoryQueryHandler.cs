using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Turbo.Application.Features.Categories.Models;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Categories.Queries.GetListCategory;

public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, CategoryListModel>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryListModel> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Category> categories = await _categoryRepository.GetListAsync(
            include: c => c.Include(p => p.Parent),
            size: request.PageRequest.PageSize, 
            index: request.PageRequest.Page, 
            cancellationToken: cancellationToken);

        CategoryListModel categoryListModel = _mapper.Map<CategoryListModel>(categories);

        return categoryListModel;
    }
}