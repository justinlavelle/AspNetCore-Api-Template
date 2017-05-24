using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Template.Interface.ServiceModels
{
    public class TestObjResponse
    {
        public IEnumerable<TestObjRecord> TestRecords;
        //public string Field3 { get; set; }
        //public string Field4 { get; set; }
    }

    public class TestObjRecord
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }

    }
}
