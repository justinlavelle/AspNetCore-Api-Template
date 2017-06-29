using HC.Template.Interface.ServiceModels.TestServiceModels;
using System.Threading.Tasks;

namespace HC.Template.Interface.Contracts
{
    public interface ITestDBService //Don't forget to add to Startup.cs for DI
    {
        TestObj1Response GetDynamicSqlData();

        TestObj2Response GetStoredProcData(TestObj2Request request);
    }
}
