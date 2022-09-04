using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Turbo.Application.Features.Authorizations.Dtos;
using Turbo.Application.Services.AuthService;
using Turbo.Application.Services.Repositories;

namespace Turbo.Application.Features.Authorizations.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
{
    readonly IUserRepository _userRepository;
    readonly IAuthService _authService;

    public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        HashingHelper.CreatePasswordHash(request.Password, out var passWordHash, out var passwordSalt);

        User user = new User
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = passWordHash,
            PasswordSalt = passwordSalt,
            Status = true,
        };

        User createdUser = await _userRepository.AddAsync(user);

        AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

        RegisteredDto registeredDto = new RegisteredDto
        {
            AccessToken = createdAccessToken
        };

        return registeredDto;
    }
}