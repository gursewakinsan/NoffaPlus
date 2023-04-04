namespace NoffaPlus.Models
{
    public class StartCleaningJobRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "cleaners_active")]
        public string CleanersActive { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "cleaning_job_id")]
        public int CleaningJobId { get; set; }
    }
}
