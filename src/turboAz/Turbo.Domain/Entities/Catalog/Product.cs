using Core.Persistence.Repositories;

namespace Turbo.Domain.Entities.Catalog;

public class Product: Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ViewCount { get; set; }
    public bool IsPro { get; set; }
    public bool IsVip { get; set; }
    public string Slug { get; set; }
    public decimal Price { get; set; }
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; }
    public bool Status { get; set; }
    public bool IsPromoted { get; set; }
    public DateTime PromotedStart { get; set; }
    public DateTime PromotedEnd { get; set; }
    public string Visibility { get; set; }
    public int PageViews { get; set; }
    public bool IsSold { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsDraft { get; set; }
    public string ContactNumber { get; set; }
    public int ProductDetailId { get; set; }
    public ProductDetail ProductDetail { get; set; }

    public Product()
    {
        
    }
    
    public Product(int id, string title, string description, int viewCount, bool isPro, bool isVip, string slug, decimal price, int currencyId, Currency currency, bool status, bool isPromoted, DateTime promotedStart, DateTime promotedEnd, string visibility, int pageViews, bool isSold, bool isDeleted, bool isDraft, string contactNumber, int productDetailId):this()
    {
        Id = id;
        Title = title;
        Description = description;
        ViewCount = viewCount;
        IsPro = isPro;
        IsVip = isVip;
        Slug = slug;
        Price = price;
        CurrencyId = currencyId;
        Currency = currency;
        Status = status;
        IsPromoted = isPromoted;
        PromotedStart = promotedStart;
        PromotedEnd = promotedEnd;
        Visibility = visibility;
        PageViews = pageViews;
        IsSold = isSold;
        IsDeleted = isDeleted;
        IsDraft = isDraft;
        ContactNumber = contactNumber;
        ProductDetailId = productDetailId;
    }
}