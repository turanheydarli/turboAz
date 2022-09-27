using MediatR;
using Turbo.Application.Features.Models.DTOs;

namespace Turbo.Application.Features.Models.Queries.GetByIdModel;

public class GetByIdModelQuery : IRequest<ModelGetByIdDto>
{
    public int Id { get; set; }
}