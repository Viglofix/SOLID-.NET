namespace LogTypeNamespace;
public enum LogType
{
    File, Database
}

public class Logger
{
    private readonly LogType _logType;

    public Logger(LogType logType)
    {
        _logType = logType;
    }

    public void Log(string message)
    {
        /* switch (_logType)
        {
            case LogType.File:
                throw new NotImplementedException();
            case LogType.Database:
                throw new NotImplementedException();
            default:
                throw new Exception("Unexpected log type!");
        } */
        
    }
}
public interface ILogger {
    public void LogType();
}
public class LoggerFile : ILogger
{
    public void LogType()
    {
        Console.WriteLine("logs has been saved to file...");
    }
}
public class LoggerDatabase : ILogger
{
    public void LogType()
    {
        Console.WriteLine("logs has been saved to database...");
    }
}
public class LoggerFax : ILogger
{
    public void LogType()
    {
        Console.WriteLine("logs has been saved to fax...");
    }
}


public class LoggManager {
    private readonly ILogger _loggManager;
    public LoggManager(ILogger logger)
    {
        _loggManager = logger;
    }
    public void SaveLogs(){
        _loggManager.LogType();
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        LoggManager loggManager = new LoggManager(new LoggerDatabase());
        loggManager.SaveLogs();
    }
}