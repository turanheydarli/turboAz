using Core.CrossCuttingConcers.Exceptions;
using MediatR;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand>
{
    private readonly IBrandRepository _brandRepository;

    public DeleteBrandCommandHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        Brand brand = await _brandRepository.GetAsync(b => b.Id == request.Id);

        if (brand == null)
            throw new BusinessException("Brand not found");

        await _brandRepository.DeleteAsync(brand);

        return new Unit();
    }
}