using HC.Template.Domain.Models;
using HC.Template.Interface.ServiceModels.TestServiceModels;
using System.Collections.Generic;

namespace HC.Template.InternalServices.Mappers.Contracts
{
    public interface ITestServiceMapper
    {
        TestObj1Response MapGetDynamicSqlData(IEnumerable<TestObj1> testRecords);
        TestObj2Response MapGetStoredProcData(IEnumerable<TestObj2> testRecords);
    }
}
