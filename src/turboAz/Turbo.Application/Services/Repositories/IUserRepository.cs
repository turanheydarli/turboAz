using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Turbo.Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User>
{
}