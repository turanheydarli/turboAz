using AutoMapper;
using MediatR;
using Turbo.Application.Features.Brands.DTOs;
using Turbo.Application.Features.Brands.Rules;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Brands.Queries.GetByIdBrand;

public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly BrandRules _brandRules;


    public GetByIdBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper, BrandRules brandRules)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _brandRules = brandRules;
    }

    public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
    {
        Brand brand = await _brandRepository.GetAsync(b => b.Id == request.Id);

        _brandRules.BrandShouldExistWhenRequested(brand);

        BrandGetByIdDto brandGetByIdDto = _mapper.Map<BrandGetByIdDto>(brand);

        return brandGetByIdDto;
    }
}