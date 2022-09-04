using Core.Security.JWT;

namespace Turbo.Application.Features.Authorizations.Dtos;

public class LoginedDto
{
    public AccessToken AccessToken { get; set; }
}