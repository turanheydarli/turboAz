using Core.Persistence.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Services.Repositories;

public interface IModelRepository : IAsyncRepository<Model>, IRepository<Model>
{
}