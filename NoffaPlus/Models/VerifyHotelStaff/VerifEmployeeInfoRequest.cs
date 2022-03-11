namespace NoffaPlus.Models
{
	public class VerifEmployeeInfoRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
		public int CompanyId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public string HotelId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "ip")]
		public string IpFromQr { get; set; }
	}
}
