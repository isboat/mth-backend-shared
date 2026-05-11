namespace MemeTokenHub.Shared.Dtos;

public class ClaimDto
{
    public string ClaimId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string TokenId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime SubmittedAt { get; set; }
}

public class CreateClaimDto
{
    public string TokenId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<string> Attachments { get; set; } = new();
}

public class ReviewClaimDto
{
    public string Status { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
}
