namespace MemeTokenHub.Shared.Dtos;

public class FollowDto
{
    public string FollowerId { get; set; } = string.Empty;
    public string FollowingId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class ActivityDto
{
    public string ActivityId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class ReputationDto
{
    public string UserId { get; set; } = string.Empty;
    public int Score { get; set; }
    public List<string> Badges { get; set; } = new();
}
