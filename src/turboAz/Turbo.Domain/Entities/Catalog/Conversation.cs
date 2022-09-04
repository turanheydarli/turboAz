using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Turbo.Domain.Entities.Catalog;

public class Conversation : Entity
{
    public int SenderId { get; set; }
    public User Sender { get; set; }
    public int ReceiverId { get; set; }
    public User Receiver { get; set; }
    public string Subject { get; set; }
}