using System.Threading.Tasks;
using HC.Template.Interface.ServiceModels.TestServiceModels;

namespace HC.Template.Interface.Contracts
{
    public interface ITestDBService
    {
        Task<TestObj1Response> GetDynamicSqlData();

        Task<TestObj2Response> GetStoredProcData(TestObj2Request request);
    }
}
