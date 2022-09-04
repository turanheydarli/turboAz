using Core.Persistence.Repositories;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;
using Turbo.Persistence.Contexts;

namespace Turbo.Persistence.Repositories;

public class BrandRepository :  EfRepositoryBase<Brand, BaseDbContext>, IBrandRepository
{
    public BrandRepository(BaseDbContext context):base(context)
    {
        
    }
}