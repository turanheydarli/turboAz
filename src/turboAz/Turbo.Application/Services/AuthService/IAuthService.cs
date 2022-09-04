using Core.Security.Entities;
using Core.Security.JWT;

namespace Turbo.Application.Services.AuthService;

public interface IAuthService
{
    Task<AccessToken> CreateAccessToken(User user);
}