namespace NoffaPlus.Models
{
    public class UpdateCleaningJobDoneRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "cleaning_job_id")]
        public int CleaningJobId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "updated_cleaning_todos")]
        public string UpdatedCleaningTodos { get; set; }
    }
}
