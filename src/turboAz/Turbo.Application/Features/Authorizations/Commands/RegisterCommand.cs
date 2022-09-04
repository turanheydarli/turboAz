using Core.Security.Dtos;
using MediatR;
using Turbo.Application.Features.Authorizations.Dtos;

namespace Turbo.Application.Features.Authorizations.Commands;

public class RegisterCommand:IRequest<RegisteredDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}