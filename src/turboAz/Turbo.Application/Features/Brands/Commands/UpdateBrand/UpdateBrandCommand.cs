using Core.Application.Pipelines.Authorization;
using MediatR;
using Turbo.Application.Features.Brands.Dtos;

namespace Turbo.Application.Features.Brands.Commands.UpdateBrand;

public class UpdateBrandCommand : IRequest<UpdatedBrandDto>, ISecuredRequest
{
    public UpdateBrandCommand(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string[] Roles => new[] { "brand.update" };

}