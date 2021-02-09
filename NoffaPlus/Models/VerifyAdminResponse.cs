namespace NoffaPlus.Models
{
	public class VerifyAdminResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "is_admin")]
		public bool IsAdmin { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_name")]
		public string CompanyName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "visiting_address")]
		public string VisitingAddress { get; set; }
	}
}
