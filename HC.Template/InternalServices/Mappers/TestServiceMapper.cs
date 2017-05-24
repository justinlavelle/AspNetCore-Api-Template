using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HC.Template.Domain.Models;
using HC.Template.Interface.ServiceModels;
using HC.Template.InternalServices.Mappers.Contracts;

namespace HC.Template.Mappers
{
    public class TestServiceMapper: ITestServiceMapper
    {
        public TestObjResponse MapGetTestRecordFromDB(IEnumerable<TestObj> testRecords)
        {
            var result = new TestObjResponse();

            foreach (var record in testRecords.ToList())
            {
                var testRecord = new TestObjRecord()
                {
                    Field1 = record.Field1,
                    Field2 = record.Field2
                };

                result.TestRecords.ToList().Add(testRecord);
            }

            return result;
        }

    }
}
