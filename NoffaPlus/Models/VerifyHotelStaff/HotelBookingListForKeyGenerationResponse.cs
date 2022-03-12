namespace NoffaPlus.Models
{
	public class HotelBookingListForKeyGenerationResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkin_code")]
		public string CheckInCode { get; set; }
	}
}
