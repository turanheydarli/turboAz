using Core.Persistence.Repositories;

namespace Turbo.Domain.Entities.Catalog;

public class ProductProperty : Entity
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; }
}