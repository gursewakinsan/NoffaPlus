using System;

namespace NoffaPlus.Models
{
	public class InviteVisitorRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
		public int CompanyId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "country_id")]
		public int CountryId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "vdate")]
		public DateTime VDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "email")]
		public string Email { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "vtime")]
		public TimeSpan VTime { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "phone")]
		public string Phone { get; set; }
	}
}
