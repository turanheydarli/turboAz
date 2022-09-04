using Core.Persistence.Repositories;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Domain.Entities.Media;

public class Picture: Entity
{
    public string ImageDefault { get; set; }
    public string ImageBig { get; set; }
    public string ImageSmall { get; set; }
    public string MimeType { get; set; }
    public int ProductDetailId { get; set; }
    public ProductDetail ProductDetail { get; set; }
    public PictureType PictureType { get; set; }
    public bool IsMain { get; set; }
}