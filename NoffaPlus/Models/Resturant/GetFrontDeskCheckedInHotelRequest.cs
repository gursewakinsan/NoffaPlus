namespace NoffaPlus.Models
{
	public class GetFrontDeskCheckedInHotelRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkout_id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_adult")]
		public int GuestAdult { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_children")]
		public int GuestChildren { get; set; }
	}
}
