using HC.Template.Domain.Models;
using HC.Template.Interface.ServiceModels;
using HC.Template.InternalServices.Mappers.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace HC.Template.InternalServices.Mappers
{
    public class TestServiceMapper: ITestServiceMapper
    {
        public TestObjResponse MapGetTestRecordFromDB(IEnumerable<TestObj1> testRecords)
        {
            var recordList = new List<TestObjRecord>();
            foreach (var record in testRecords.ToList())
            {
                var testRecord = new TestObjRecord()
                {
                    Field1 = record.Field1,
                    Field2 = record.Field2
                };
                recordList.Add(testRecord);
            }

            var result = new TestObjResponse()
            {
                TestRecords = recordList.AsEnumerable()
            };

            return result;
        }

    }
}
