namespace NoffaPlus.Models
{
	public class HotelBookingListForFrontDeskCheckinResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
		public string FirstName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
		public string LastName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_adult")]
		public int GuestAdult { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_children")]
		public int GuestChildren { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkin_booking_date")]
		public string CheckinBookingDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkout_booking_date")]
		public string CheckoutBookingDate { get; set; }
	}
}
