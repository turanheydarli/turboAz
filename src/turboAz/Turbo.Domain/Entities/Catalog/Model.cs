using Core.Persistence.Repositories;

namespace Turbo.Domain.Entities.Catalog;

public class Model : Entity
{
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public string Name { get; set; }
}