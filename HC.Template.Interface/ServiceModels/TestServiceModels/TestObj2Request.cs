using System.ComponentModel.DataAnnotations;

namespace HC.Template.Interface.ServiceModels.TestServiceModels
{
    public class TestObj2Request
    {
        [Required]
        public int SupportRepId { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
