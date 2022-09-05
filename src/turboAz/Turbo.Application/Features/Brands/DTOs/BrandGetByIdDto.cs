using Turbo.Application.Services.Mapping;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Brands.DTOs;

public class BrandGetByIdDto : IMapFrom<Brand>
{
    public int Id { get; set; }
    public string Name { get; set; }
}