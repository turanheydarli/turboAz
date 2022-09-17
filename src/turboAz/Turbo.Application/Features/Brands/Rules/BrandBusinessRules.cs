using Core.CrossCuttingConcers.Exceptions;
using Turbo.Application.Features.Brands.Constants;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Brands.Rules;

public class BrandBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task BrandNameShouldNotBeExisted(string brandName)
    {
        Brand result = await _brandRepository.GetAsync(b => b.Name == brandName);
        if (result != null) throw new BusinessException(BrandMessages.BrandNameExist);
    }

    public void BrandShouldExistWhenRequested(Brand brand)
    {
        if (brand == null) throw new BusinessException(BrandMessages.BrandDoesNotExist);
    }
    
    public async Task BrandShouldExistWhenRequested(int brandId)
    {
        Brand result = await _brandRepository.GetAsync(b => b.Id == brandId);
        if (result == null) throw new BusinessException(BrandMessages.BrandNameExist);
    }
}