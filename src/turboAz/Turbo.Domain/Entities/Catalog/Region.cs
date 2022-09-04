using Core.Persistence.Repositories;

namespace Turbo.Domain.Entities.Catalog;

public class Region : Entity
{
    public string Name { get; set; }
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
}