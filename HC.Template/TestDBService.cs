using HC.Template.Interface.Contracts;
using System;
using HC.Template.Interface.ServiceModels;
using System.Threading.Tasks;
using HC.Template.Infrastructure.Repositories.HealthCheck.Contracts;
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

        public async Task<TestObjResponse> GetTestRecordFromDB()
        {
            var response = await _testRepo.GetTestRecord();
            var result = _mapper.MapGetTestRecordFromDB(response);

            return result;
        }
    }
}
