namespace HC.Template.Infrastructure.Logging.Contracts
{
    public interface ILoggerService
    {
        void LogDebug(string debug);

        void LogInformation(string info);
    }
}
