using MediatR;
using Turbo.Application.Features.Products.Dtos;

namespace Turbo.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<CreatedProductDto>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ContactNumber { get; set; }

}