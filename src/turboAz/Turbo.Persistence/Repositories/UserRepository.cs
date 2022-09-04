using Core.Persistence.Repositories;
using Core.Security.Entities;
using Turbo.Application.Services.Repositories;
using Turbo.Persistence.Contexts;

namespace Turbo.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context)
    {
    }
}