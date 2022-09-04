using Core.CrossCuttingConcers.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcers.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Core.CrossCuttingConcers.Logging.Serilog.Loggers;

public class FileLogger : LoggerServiceBase
{

    public FileLogger(IConfiguration configuration)
    {

        FileLogConfiguration logConfig = configuration.GetSection("SeriLogConfigurations:FileLogConfiguration")
                                             .Get<FileLogConfiguration>() ??
                                         throw new Exception(SerilogMessages.NullOptionsMessage);

        string logFilePath = $"{Directory.GetCurrentDirectory() + logConfig.FolderPath}.txt";

        Logger = new LoggerConfiguration()
            .WriteTo.File(
                logFilePath,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: null,
                fileSizeLimitBytes: 5000000,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();
    }
}