namespace NoffaPlus.Models
{
	public class ContactResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "passport_image")]
		public string PassportImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
		public string FirstName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_name")]
		public string CompanyName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "email")]
		public string Email { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
		public int CompanyId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_login_id")]
		public int UserLoginId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "image")]
		public string Image { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
		public string Enc { get; set; }
	}
}
