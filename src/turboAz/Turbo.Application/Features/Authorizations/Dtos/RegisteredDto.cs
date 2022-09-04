using Core.Security.JWT;

namespace Turbo.Application.Features.Authorizations.Dtos;

public class RegisteredDto
{
    public AccessToken AccessToken { get; set; }
}