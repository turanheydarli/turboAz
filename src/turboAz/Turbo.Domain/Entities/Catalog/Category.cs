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

    public Category()
    {
    }
    public Category(int id, string slug, int? parentId, 
        string title, string name, string description, 
        string keywords, int categoryOrder, int homepageOrder,
        bool showProductsOnIndex, bool isFeatured, 
        int featuredOrder, bool visibility, bool showImageOnNavigation)
    {
        Id = id;
        Slug = slug;
        ParentId = parentId;
        Title = title;
        Name = name;
        Description = description;
        Keywords = keywords;
        CategoryOrder = categoryOrder;
        HomepageOrder = homepageOrder;
        ShowProductsOnIndex = showProductsOnIndex;
        IsFeatured = isFeatured;
        FeaturedOrder = featuredOrder;
        Visibility = visibility;
        ShowImageOnNavigation = showImageOnNavigation;
    }
}