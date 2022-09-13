using Core.Persistence.Repositories;

namespace Turbo.Domain.Entities.Catalog;

public class Brand : Entity
{
    public ICollection<Model> Models { get; set; }
    public string Name { get; set; }

    public Brand()
    {
    }

    public Brand(int id, string name)
    {
        Id = id;
        Name = name;
    }
}