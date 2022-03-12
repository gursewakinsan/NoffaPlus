namespace NoffaPlus.Models
{
	public class HotelBookingInstaBoxListForKeyGenerationResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "box_number")]
		public int BoxNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "instaBox")]
		public string InstaBoxInfo { get; set; }
	}
}
