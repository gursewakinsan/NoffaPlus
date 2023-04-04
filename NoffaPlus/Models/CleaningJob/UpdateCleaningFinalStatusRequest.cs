namespace NoffaPlus.Models
{
    public class UpdateCleaningFinalStatusRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "cleaning_job_id")]
        public int CleaningJobId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "if_rentable")]
        public int IfRentable { get; set; }
    }
}