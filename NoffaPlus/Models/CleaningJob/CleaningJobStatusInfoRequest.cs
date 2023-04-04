namespace NoffaPlus.Models
{
    public class CleaningJobStatusInfoRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "cleaning_job_id")]
        public int CleaningJobId { get; set; }
    }
}
