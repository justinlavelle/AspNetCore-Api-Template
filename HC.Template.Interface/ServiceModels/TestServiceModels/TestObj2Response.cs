using System.Collections.Generic;

namespace HC.Template.Interface.ServiceModels.TestServiceModels
{
    public class TestObj2Response
    {
        public IEnumerable<TestObj2Record> TestRecords;
    }

    public class TestObj2Record
    {
        public string Field6 { get; set; }
        public string Field8 { get; set; }
    }
}
