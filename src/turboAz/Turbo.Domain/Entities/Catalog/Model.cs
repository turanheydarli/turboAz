using Core.Persistence.Repositories;

namespace Turbo.Domain.Entities.Catalog;

public class Model : Entity
{
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }

    public Model()
    {
    }

    public Model(int id, string name, int brandId, string imageUrl)
    {
        Id = id;
        BrandId = brandId;
        Name = name;
        ImageUrl = imageUrl;
    }
}