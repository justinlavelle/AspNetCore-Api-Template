namespace HC.Template.Infrastructure.Logging
{
    public interface ILoggerService
    {
        void LogDebug(string debug);

        void LogInformation(string info);
    }
}
