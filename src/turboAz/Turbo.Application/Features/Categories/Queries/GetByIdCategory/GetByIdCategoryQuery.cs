using MediatR;
using Turbo.Application.Features.Categories.DTOs;

namespace Turbo.Application.Features.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQuery : IRequest<CategoryGetByIdDto>
{
    public GetByIdCategoryQuery(int id)
    {
        Id = id;
    }

    public GetByIdCategoryQuery()
    {
    }

    public int Id { get; set; }
}