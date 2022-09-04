using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using Turbo.Application.Services.Repositories;

namespace Turbo.Application.Services.AuthService;

public class AuthService : IAuthService
{
    readonly IUserOperationClaimRepository _userOperationClaimRepository;
    readonly ITokenHelper _tokenHelper;

    public AuthService(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _tokenHelper = tokenHelper;
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        IPaginate<UserOperationClaim> userOperationClaims =
            await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                include: u =>
                    u.Include(c => c.OperationClaim)
            );
        List<OperationClaim> operationClaims =
            userOperationClaims.Items.Select(u => new OperationClaim
                { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();

        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }
}