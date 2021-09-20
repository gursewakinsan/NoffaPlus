namespace NoffaPlus.Models
{
	public class UpdateInServicingRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_id")]
		public int GuestId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }
	}
}
