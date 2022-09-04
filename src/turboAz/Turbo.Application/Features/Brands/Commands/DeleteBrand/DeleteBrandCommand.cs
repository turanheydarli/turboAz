using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Turbo.Application.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommand : IRequest, ISecuredRequest
{
    public DeleteBrandCommand() { }
    public DeleteBrandCommand(int id)
    {
        Id = id;
    }
    
    public int Id { get; set; }
    public string[] Roles => new[] { "brand.delete" };
}