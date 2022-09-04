using Core.Persistence.Repositories;
using Core.Security.Entities;
using Turbo.Application.Services.Repositories;
using Turbo.Persistence.Contexts;

namespace Turbo.Persistence.Repositories;

public class UserOperationClaimRepository:EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}