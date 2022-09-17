using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using Turbo.Application.Services.Repositories;

namespace Turbo.Application.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenHelper _tokenHelper;

    public AuthService(IUserRepository userRepository, ITokenHelper tokenHelper)
    {
        _userRepository = userRepository;
        _tokenHelper = tokenHelper;
    }


    public async Task<AccessToken> CreateAccessToken(User appUser)
    {
        User user = await _userRepository.GetAsync(
            predicate: u => u.Id == appUser.Id,
            include: u => u.Include(p => p.UserOperationClaims)
                .ThenInclude(o => o.OperationClaim));

        IEnumerable<OperationClaim> operationClaims = user.UserOperationClaims.Select(o => o.OperationClaim);
            
        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims.ToList());
        
        return accessToken;
    }
}