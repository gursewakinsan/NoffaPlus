namespace NoffaPlus.Models
{
	public class AvailableResturantRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
		public int CompanyId { get; set; }
	}
}
