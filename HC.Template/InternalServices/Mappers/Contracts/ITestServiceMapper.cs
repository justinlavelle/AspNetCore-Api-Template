using System;
using System.Collections.Generic;
using System.Text;
using HC.Template.Domain.Models;
using HC.Template.Interface.ServiceModels;

namespace HC.Template.InternalServices.Mappers.Contracts
{
    public interface ITestServiceMapper
    {
        TestObjResponse MapGetTestRecordFromDB(IEnumerable<TestObj> testRecords);
    }
}
