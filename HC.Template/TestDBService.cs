using System;
using System.Threading.Tasks;
using HC.Template.Infrastructure.Repositories.HealthCheck.Contracts;
using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels.TestServiceModels;
using HC.Template.InternalServices.Mappers.Contracts;

namespace HC.Template.Service
{
    public class TestDBService : ITestDBService
    {
        private ITestRepo _testRepo;
        private ITestServiceMapper _mapper;

        public TestDBService(ITestRepo testRepo, ITestServiceMapper mapper)
        {
            _testRepo = testRepo;
            _mapper = mapper;
        }

        public async Task<TestObj1Response> GetDynamicSqlData()
        {
            try
            {
                var response = await _testRepo.GetDynamicSqlRecord();
                var result = _mapper.MapGetDynamicSqlData(response);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TestObj2Response> GetStoredProcData(TestObj2Request request)
        {
            var response = await _testRepo.GetStoredProcRecord(request.Parameter1, request.Parameter2);
            var result = _mapper.MapGetStoredProcData(response);

            return result;

        }
    }
}
