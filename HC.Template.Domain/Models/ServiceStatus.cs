namespace HC.Template.Domain.Models
{
    /// <summary>
    /// ServiceStatus to hold the response. 
    /// </summary>
    public class ServiceStatus
    {
        public ServiceStatus(bool available)
        {
            Available = available;
        }

        /// <summary>
        /// Tells if the service is available
        /// </summary>
        /// <returns>True if the service is available</returns>
        public bool Available { get; set; }
    }

}
