using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Turbo.Domain.Entities.Catalog;

public class ConversationMessage: Entity
{
    public int SenderId { get; set; }
    public User Sender { get; set; }
    public int ReceiverId { get; set; }
    public User Receiver { get; set; }
    public string Subject { get; set; }
    public int ConversationId { get; set; }
    public Conversation Conversation { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
    public int DeletedUserId { get; set; }
    public User DeletedUser { get; set; }
}