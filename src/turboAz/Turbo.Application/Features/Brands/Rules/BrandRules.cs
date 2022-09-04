using Core.CrossCuttingConcers.Exceptions;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Brands.Rules;

public class BrandRules
{
    readonly IBrandRepository _brandRepository;

    public BrandRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task BrandNameShouldNotBeExisted(string productName)
    {
        Brand result = await _brandRepository.GetAsync(b => b.Name == productName);
        if (result != null) throw new BusinessException("Brand zaten mevcut");
    }
}