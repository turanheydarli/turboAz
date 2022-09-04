using AutoMapper;
using Core.CrossCuttingConcers.Exceptions;
using MediatR;
using Turbo.Application.Features.Brands.Dtos;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Brands.Commands.UpdateBrand;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandDto>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public UpdateBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
    {
        _mapper = mapper;
        _brandRepository = brandRepository;
    }

    public async Task<UpdatedBrandDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        Brand brand = await _brandRepository.GetAsync(b => b.Id == request.Id);

        if (brand == null)
            throw new BusinessException("brand not found");

        brand.Name = request.Name;
        brand.UpdatedTime = DateTime.UtcNow;
        
        await _brandRepository.UpdateAsync(brand);

        return _mapper.Map<UpdatedBrandDto>(brand);
    }
}