using AutoMapper;
using MediatR;
using Turbo.Application.Features.Brands.DTOs;
using Turbo.Application.Features.Brands.Rules;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
{
    private readonly IBrandRepository _brandRepository;
    private readonly BrandRules _brandRules;
    private readonly IMapper _mapper;

    public CreateBrandCommandHandler(BrandRules brandRules, IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRules = brandRules;
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        await _brandRules.BrandNameShouldNotBeExisted(request.Name);

        Brand brand = _mapper.Map<Brand>(request);
        Brand createdBrand =  await _brandRepository.AddAsync(brand);
        CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand);

        return createdBrandDto;
    }
}