namespace NoffaPlus.Models
{
	public class GetAvailableRoomsRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "checkout_id")]
		public int CheckoutId { get; set; }
	}
}
