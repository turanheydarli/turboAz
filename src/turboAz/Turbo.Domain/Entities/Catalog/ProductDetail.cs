using Core.Persistence.Repositories;
using Turbo.Domain.Entities.Media;

namespace Turbo.Domain.Entities.Catalog;

public class ProductDetail : Entity
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public string Description { get; set; }
    public int RegionId { get; set; }
    public Region Region { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public bool IsLoan { get; set; }
    public bool IsBarter { get; set; }
    public long Mileage { get; set; }
    public bool IsNew { get; set; }
    public ICollection<ProductProperty> Properties { get; set; }
    public ICollection<Picture> Pictures { get; set; }
}