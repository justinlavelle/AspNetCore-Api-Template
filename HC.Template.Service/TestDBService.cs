using HC.Template.Factories.Contracts;
using HC.Template.Interface.Contracts;
using HC.Template.Interface.ServiceModels.TestServiceModels;
using HC.Template.Service.InternalServices.Mappers.Contracts;

namespace HC.Template.Service
{
    public class TestDBService : ITestDBService
    {
        private IUowFactory _uowFactory;
        private ITestServiceMapper _mapper;

        public TestDBService(ITestServiceMapper mapper, IUowFactory uowFactory)
        {
            _mapper = mapper;
            _uowFactory = uowFactory;
        }

        /// <summary>
        /// Gets data based on Dynamic Sql
        /// </summary>
        /// <returns></returns>
        public TestObj1Response GetDynamicSqlData()
        {
            using (var uow = _uowFactory.GetUnitOfWork())
            {
                var response = uow.TestRepo.GetDynamicSqlRecord();
                var commitSuccess = uow.Commit();

                var result = _mapper.MapGetDynamicSqlData(response);
                return result;
            }
        }

        /// <summary>
        /// Gets data from a stored procedure
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public TestObj2Response GetStoredProcData(TestObj2Request request)
        {
            using (var uow = _uowFactory.GetUnitOfWork())
            {

                var response = uow.TestRepo.GetStoredProcRecord(request.SupportRepId, request.Country);
                var commitSuccess = uow.Commit();

                var result = _mapper.MapGetStoredProcData(response);
                return result;

            }
        }
    }
}
