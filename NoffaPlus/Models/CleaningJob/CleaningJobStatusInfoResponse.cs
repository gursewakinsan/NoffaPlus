namespace NoffaPlus.Models
{
    public class CleaningJobStatusInfoResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "job_started")]
        public string JobStarted { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "service_type_id")]
        public int ServiceTypeId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "category_name")]
        public string CategoryName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "port_number")]
        public string PortNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "cleaning_job_status")]
        public int CleaningJobStatus { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "job_end")]
        public string JobEnd { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "team_leader")]
        public string TeamLeader { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "team_count")]
        public int TeamCount { get; set; }
    }
}
