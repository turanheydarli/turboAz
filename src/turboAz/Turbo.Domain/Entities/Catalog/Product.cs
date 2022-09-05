using Core.Persistence.Repositories;

namespace Turbo.Domain.Entities.Catalog;

public class Product : Entity
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

}