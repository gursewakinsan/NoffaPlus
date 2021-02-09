namespace NoffaPlus.Models
{
	public class VerifyAdminRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "companyId")]
		public int CompanyId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "userId")]
		public int UserId { get; set; }
	}
}
