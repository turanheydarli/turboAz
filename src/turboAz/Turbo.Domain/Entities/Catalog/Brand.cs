using Core.Persistence.Repositories;

namespace Turbo.Domain.Entities.Catalog;

public class Brand : Entity
{
    public IEnumerable<Model> Models { get; set; }
    public string Name { get; set; }
}