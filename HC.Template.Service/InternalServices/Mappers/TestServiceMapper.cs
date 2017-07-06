using HC.Template.Domain.Models;
using HC.Template.Interface.ServiceModels.TestServiceModels;
using HC.Template.Service.InternalServices.Mappers.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace HC.Template.Service.InternalServices.Mappers // Internal services are never meant to be exposed to an external consumer. Hence Internal services
{
    public class TestServiceMapper: ITestServiceMapper
    {
        public TestObj1Response MapGetDynamicSqlData(IEnumerable<TestObj1> testRecords)
        {
            var recordList = new List<TestObj1Record>();
            foreach (var record in testRecords.ToList())
            {
                var testRecord = new TestObj1Record()
                {
                    Field1 = record.Field1,
                    Field2 = record.Field2
                };
                recordList.Add(testRecord);
            }

            var result = new TestObj1Response()
            {
                TestRecords = recordList.AsEnumerable()
            };

            return result;
        }

        public TestObj2Response MapGetStoredProcData(IEnumerable<TestObj2> testRecords)
        {
            var recordList = new List<TestObj2Record>();
            foreach (var record in testRecords.ToList())
            {
                var testRecord = new TestObj2Record()
                {
                    CustomerId = record.CustomerId,
                    FirstName = record.FirstName,
                    LastName = record.LastName
                };
                recordList.Add(testRecord);
            }

            var result = new TestObj2Response()
            {
                TestRecords = recordList.AsEnumerable()
            };

            return result;
        }
    }
}
