using HC.Template.Infrastructure.Logging.Contracts;
using Microsoft.Extensions.Logging;

namespace HC.Template.Infrastructure.Logging
{
    public class LoggerService : ILoggerService
    {
        private ILogger<LoggerService> _logger;
        public LoggerService(ILogger<LoggerService> logger)
        {
            _logger = logger;
        }

        public void LogDebug(string debug)
        {
            _logger.LogDebug(debug);
        }

        public void LogInformation(string info)
        {
            _logger.LogInformation(info);
        }
    }
}
