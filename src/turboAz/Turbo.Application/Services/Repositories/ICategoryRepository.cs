using Core.Persistence.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Services.Repositories;

public interface ICategoryRepository : IRepository<Category>, IAsyncRepository<Category>
{
    
}