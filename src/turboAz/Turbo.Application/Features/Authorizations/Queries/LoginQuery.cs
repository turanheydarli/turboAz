using MediatR;
using Turbo.Application.Features.Authorizations.Dtos;

namespace Turbo.Application.Features.Authorizations.Queries;

public class LoginQuery : IRequest<LoginedDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}