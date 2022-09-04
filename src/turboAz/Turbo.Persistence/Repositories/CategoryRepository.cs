using Core.Persistence.Repositories;
using Turbo.Application.Services.Repositories;
using Turbo.Domain.Entities.Catalog;
using Turbo.Persistence.Contexts;

namespace Turbo.Persistence.Repositories;

public class CategoryRepository: EfRepositoryBase<Category,BaseDbContext>, ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context) { }
}