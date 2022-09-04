using Core.Persistence.Repositories;

namespace Turbo.Domain.Entities.Catalog;

public class Currency : Entity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public string CurrencyFormat { get; set; }
    public bool Status { get; set; }
}