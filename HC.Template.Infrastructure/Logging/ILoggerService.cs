using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.Infrastructure
{
    public interface ILoggerService
    {
        void LogDebug(string debug);

        void LogInformation(string info);
    }
}
