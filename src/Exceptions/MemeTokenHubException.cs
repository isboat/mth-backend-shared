namespace MemeTokenHub.Shared.Exceptions;

public class MemeTokenHubException : Exception
{
    public string Code { get; set; }

    public MemeTokenHubException(string message, string code = "UNKNOWN_ERROR")
        : base(message)
    {
        Code = code;
    }
}

public class NotFoundException : MemeTokenHubException
{
    public NotFoundException(string resource, string id)
        : base($"{resource} with id {id} not found", "NOT_FOUND") { }
}

public class UnauthorizedException : MemeTokenHubException
{
    public UnauthorizedException(string message = "Unauthorized")
        : base(message, "UNAUTHORIZED") { }
}

public class ForbiddenException : MemeTokenHubException
{
    public ForbiddenException(string message = "Access forbidden")
        : base(message, "FORBIDDEN") { }
}

public class ValidationException : MemeTokenHubException
{
    public List<string> Errors { get; set; }

    public ValidationException(List<string> errors)
        : base("Validation failed", "VALIDATION_ERROR")
    {
        Errors = errors;
    }
}
