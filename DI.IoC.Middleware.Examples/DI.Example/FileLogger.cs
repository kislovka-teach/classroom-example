namespace DI.Example;

public class FileLogger : ILogger
{
    private const string LogFilePath = "logger.txt";

    public void LogInfo(string logMessage)
    {
        File.WriteAllLines(LogFilePath, new[] { logMessage });
    }
}