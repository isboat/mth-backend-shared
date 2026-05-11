namespace MemeTokenHub.Shared.Messaging;

public interface IEventMessage
{
    string EventType { get; }
    DateTime OccurredAt { get; }
}

public class ClaimApprovedEvent : IEventMessage
{
    public string EventType => "ClaimApproved";
    public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
    public string ClaimId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string TokenId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}

public class UserUpdatedEvent : IEventMessage
{
    public string EventType => "UserUpdated";
    public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
    public string UserId { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
