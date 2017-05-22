using HC.Template.Interface.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HC.Template.Interface.Contracts
{
    public interface ITestService
    {
        Task<TestObjResponse> GetTestRecordFromDB();
    }
}
