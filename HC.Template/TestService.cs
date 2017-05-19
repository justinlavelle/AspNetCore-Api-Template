using HC.Template.Interface.Contracts;
using System;
using HC.Template.Interface.ServiceModels;
using System.Threading.Tasks;
using HC.Template.Infrastructure.Repositories.HealthCheck.Contracts;

namespace HC.Template
{
    public class TestService : ITestService
    {
        private ITestRepo _testRepo;

        public TestService(ITestRepo testRepo)
        {
            _testRepo = testRepo;
        }

        public async Task<TestResponse> GetTestRecordFromDB()
        {
            var response = await _testRepo.GetTestRecord();
            throw new NotImplementedException();
        }
    }
}
