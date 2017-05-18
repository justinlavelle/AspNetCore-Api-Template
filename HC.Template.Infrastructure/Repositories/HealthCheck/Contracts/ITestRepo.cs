using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Contracts
{
    public interface ITestRepo
    {
        bool GetDbRecord();
    }

}