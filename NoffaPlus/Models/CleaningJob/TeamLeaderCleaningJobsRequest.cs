namespace NoffaPlus.Models
{
    public class TeamLeaderCleaningJobsRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "aid")]
        public string AId { get; set; }
    }
}