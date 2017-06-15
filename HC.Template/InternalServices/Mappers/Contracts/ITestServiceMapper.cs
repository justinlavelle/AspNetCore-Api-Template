using System.Collections.Generic;
using HC.Template.Domain.Models;
using HC.Template.Interface.ServiceModels.TestServiceModels;

namespace HC.Template.InternalServices.Mappers.Contracts
{
    public interface ITestServiceMapper
    {
        TestObj1Response MapGetDynamicSqlData(IEnumerable<TestObj1> testRecords);
        TestObj2Response MapGetStoredProcData(IEnumerable<TestObj2> testRecords);
    }
}
