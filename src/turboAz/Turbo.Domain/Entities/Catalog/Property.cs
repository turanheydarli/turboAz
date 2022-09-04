using Core.Persistence.Repositories;

namespace Turbo.Domain.Entities.Catalog;

public class Property : Entity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public bool IsMain { get; set; }
}