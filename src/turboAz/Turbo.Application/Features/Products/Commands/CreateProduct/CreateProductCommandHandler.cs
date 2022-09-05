using MediatR;
using Turbo.Application.Features.Products.DTOs;

namespace Turbo.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductDto>
{
    public Task<CreatedProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}