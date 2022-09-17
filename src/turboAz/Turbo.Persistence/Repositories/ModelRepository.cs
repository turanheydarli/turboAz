using Core.Persistence.Repositories;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;
using Turbo.Persistence.Contexts;

namespace Turbo.Persistence.Repositories;

public class ModelRepository : EfRepositoryBase<Model, BaseDbContext>, IModelRepository
{
    public ModelRepository(BaseDbContext context) : base(context)
    {
    }
}