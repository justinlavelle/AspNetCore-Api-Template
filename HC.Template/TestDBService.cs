using System;
using System.Threading.Tasks;
using HC.Template.Factories;
using HC.Template.Factories.Contracts;
using HC.Template.Infrastructure.Repositories.HealthCheck.Contracts;
using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels.TestServiceModels;
using HC.Template.InternalServices.Mappers.Contracts;

namespace HC.Template.Service
{
    public class TestDBService : ITestDBService
    {
        private IUowFactory _uowFactory;
        //private ITestRepo _testRepo;
        private ITestServiceMapper _mapper;

        public TestDBService( ITestServiceMapper mapper, IUowFactory uowFactory)
        {
            _mapper = mapper;
            _uowFactory = uowFactory;
        }

        public async Task<TestObj1Response> GetDynamicSqlData()
        {
            using (var uow = _uowFactory.GetUnitOfWork())
            {
                try
                {
                    var response = await uow.TestRepo.GetDynamicSqlRecord();
                    var commitSuccess = uow.Commit();

                    var result = _mapper.MapGetDynamicSqlData(response);
                    return result;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<TestObj2Response> GetStoredProcData(TestObj2Request request)
        {
            using (var uow = _uowFactory.GetUnitOfWork())
            {
                try
                {
                    var response = await uow.TestRepo.GetStoredProcRecord(request.Parameter1, request.Parameter2);
                    var commitSuccess = uow.Commit();

                    var result = _mapper.MapGetStoredProcData(response);
                    return result;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
