using HC.Template.Domain.Models;
using HC.Template.Interface.ServiceModels;
using HC.Template.InternalServices.Mappers.Contracts;
using System.Collections.Generic;
using System.Linq;
using HC.Template.Interface.ServiceModels.TestServiceModels;
using System;

namespace HC.Template.InternalServices.Mappers
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
                    Field6 = record.Field6,
                    Field8 = record.Field8
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
