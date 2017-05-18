using HC.Template.Infrastructure.Base;
using HC.Template.Infrastructure.Repositories.HealthCheck.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.Infrastructure.Repositories.HealthCheck.Repo
{
    public class TestRepo: BaseRepo, ITestRepo
    {
        public bool GetDbRecord()
        {
            throw new NotImplementedException();
        }
    }
}
