namespace NoffaPlus.Models
{
	public class UpdateVacationRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
		public int CompanyId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "start_date")]
		public string StartDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "end_date")]
		public string EndDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "leave_description")]
		public string LeaveDescription { get; set; }
	}
}

