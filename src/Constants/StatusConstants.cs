namespace MemeTokenHub.Shared.Constants;

public static class UserRoles
{
    public const string Anonymous = "Anonymous";
    public const string Authenticated = "Authenticated";
    public const string Creator = "Creator";
    public const string Collector = "Collector";
    public const string Moderator = "Moderator";
}

public static class ClaimStatus
{
    public const string Pending = "Pending";
    public const string Approved = "Approved";
    public const string Rejected = "Rejected";
}

public static class TokenStatus
{
    public const string Unclaimed = "Unclaimed";
    public const string Claimed = "Claimed";
    public const string Featured = "Featured";
}

public static class PaymentStatus
{
    public const string Pending = "Pending";
    public const string Completed = "Completed";
    public const string Failed = "Failed";
}

public static class ActivityType
{
    public const string ClaimSubmitted = "ClaimSubmitted";
    public const string TokenPublished = "TokenPublished";
    public const string UserFollowed = "UserFollowed";
}
