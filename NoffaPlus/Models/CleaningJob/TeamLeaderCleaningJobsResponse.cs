namespace NoffaPlus.Models
{
    public class TeamLeaderCleaningJobsResponse
    {
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

        [Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
        public string Enc { get; set; }

        public Xamarin.Forms.Color CircleBg { get; set; }

        public bool IsAction { get; set; }

        public bool NotClean { get; set; } = false;

        public bool CleaningStart  { get; set; } = false;

        public bool Cleaned { get; set; } = false;
    }
}
