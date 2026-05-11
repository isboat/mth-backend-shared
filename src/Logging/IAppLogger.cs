namespace MemeTokenHub.Shared.Logging;

public interface IAppLogger
{
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message, Exception? ex = null);
    void LogDebug(string message);
}
