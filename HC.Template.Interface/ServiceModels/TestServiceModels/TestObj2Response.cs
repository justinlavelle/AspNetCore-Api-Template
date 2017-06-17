using System.Collections.Generic;

namespace HC.Template.Interface.ServiceModels.TestServiceModels
{
    public class TestObj2Response
    {
        public IEnumerable<TestObj2Record> TestRecords;
    }

    public class TestObj2Record
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
