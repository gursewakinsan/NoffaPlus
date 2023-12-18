namespace NoffaPlus.Models
{
    public class WorkingHrs
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "work_time")]
        public string WorkTime { get; set; }
    }
}
