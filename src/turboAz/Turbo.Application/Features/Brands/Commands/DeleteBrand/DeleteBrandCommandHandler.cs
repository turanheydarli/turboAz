using Core.CrossCuttingConcers.Exceptions;
using MediatR;
using Turbo.Application.Features.Brands.Rules;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand>
{
    private readonly IBrandRepository _brandRepository;
    private readonly BrandBusinessRules _brandBusinessRules;
    public DeleteBrandCommandHandler(IBrandRepository brandRepository, BrandBusinessRules brandBusinessRules)
    {
        _brandRepository = brandRepository;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        Brand brand = await _brandRepository.GetAsync(b => b.Id == request.Id);

        _brandBusinessRules.BrandShouldExistWhenRequested(brand);

        await _brandRepository.DeleteAsync(brand);

        return new Unit();
    }
}