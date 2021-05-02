namespace NoffaPlus.Models
{
	public class UpdateLeaveRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
		public int CompanyId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "day_leave")]
		public int DayLeave { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "leave_description")]
		public string LeaveDescription { get; set; }
	}
}
