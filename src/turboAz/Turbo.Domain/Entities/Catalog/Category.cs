using Core.Persistence.Repositories;

namespace Turbo.Domain.Entities.Catalog;

public class Category : Entity
{
    public string Slug { get; set; }
    public int? ParentId { get; set; }
    public Category Parent { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Keywords { get; set; }
    public int CategoryOrder { get; set; }
    public int HomepageOrder { get; set; }
    public bool ShowProductsOnIndex { get; set; }
    public bool IsFeatured { get; set; }
    public int FeaturedOrder { get; set; }
    public bool Visibility { get; set; }
    public bool ShowImageOnNavigation { get; set; }
    
}