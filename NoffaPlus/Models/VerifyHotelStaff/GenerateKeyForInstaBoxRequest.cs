namespace NoffaPlus.Models
{
	public class GenerateKeyForInstaBoxRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public string HotelId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "booking_id")]
		public int BookingId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "insta_box_id")]
		public int InstaBoxId { get; set; }
	}
}
