using System.Security.Claims;

namespace MemeTokenHub.Shared.Auth;

public interface ITokenService
{
    string GenerateToken(string userId, string role, int expirationMinutes = 60);
    ClaimsPrincipal ValidateToken(string token);
}
