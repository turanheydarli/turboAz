using MediatR;
using Turbo.Application.Features.Brands.DTOs;

namespace Turbo.Application.Features.Brands.Queries.GetByIdBrand;

public class GetByIdBrandQuery : IRequest<BrandGetByIdDto>
{
    public GetByIdBrandQuery()
    {
    }

    public GetByIdBrandQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}