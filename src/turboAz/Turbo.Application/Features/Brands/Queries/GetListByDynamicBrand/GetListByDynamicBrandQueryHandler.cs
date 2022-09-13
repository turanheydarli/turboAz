using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using Turbo.Application.Features.Brands.Models;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Brands.Queries.GetListByDynamicBrand;

public class GetListByDynamicBrandQueryHandler : IRequestHandler<GetListByDynamicBrandQuery, BrandListModel>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetListByDynamicBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<BrandListModel> Handle(GetListByDynamicBrandQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Brand> brands = await _brandRepository.GetListByDynamicAsync(
            dynamic: request.Dynamic,
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken);

        BrandListModel mappedBrandList = _mapper.Map<BrandListModel>(brands);

        return mappedBrandList;
    }
}