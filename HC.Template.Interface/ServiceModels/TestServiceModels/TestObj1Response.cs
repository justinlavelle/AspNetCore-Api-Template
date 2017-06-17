using System.Collections.Generic;

namespace HC.Template.Interface.ServiceModels.TestServiceModels
{
    public class TestObj1Response
    {
        public IEnumerable<TestObj1Record> TestRecords;
    }

    public class TestObj1Record
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }

    }
}
