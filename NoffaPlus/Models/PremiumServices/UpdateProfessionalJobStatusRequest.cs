namespace NoffaPlus.Models
{
    public class UpdateProfessionalJobStatusRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "job_id")]
        public int JobId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "job_status")]
        public string JobStatus { get; set; }
    }
}