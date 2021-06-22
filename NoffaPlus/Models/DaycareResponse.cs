namespace NoffaPlus.Models
{
	public class DaycareResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "received")]
		public int Received { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "picked")]
		public int Picked { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "ttl")]
		public int Total { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "inactive")]
		public int Inactive { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "duns_is_approved")]
		public int DunsIsApproved { get; set; }
	}
}
