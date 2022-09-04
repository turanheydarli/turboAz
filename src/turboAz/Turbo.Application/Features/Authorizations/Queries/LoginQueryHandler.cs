using Core.CrossCuttingConcers.Exceptions;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Turbo.Application.Features.Authorizations.Dtos;
using Turbo.Application.Services.AuthService;
using Turbo.Application.Services.Repositories;

namespace Turbo.Application.Features.Authorizations.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginedDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public LoginQueryHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<LoginedDto> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(u => u.Email == request.Email && u.Status);

        if (user == null)
            throw new BusinessException("user not found");

        if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException("password is wrong");

        AccessToken accessToken = await _authService.CreateAccessToken(user);

        //await _userRepository.UpdateAsync(user); TODO: RefreshToken Things

        return new LoginedDto { AccessToken = accessToken };
    }
}