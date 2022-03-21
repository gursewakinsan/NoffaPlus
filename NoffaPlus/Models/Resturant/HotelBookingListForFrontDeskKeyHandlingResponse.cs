namespace NoffaPlus.Models
{
	public class HotelBookingListForFrontDeskKeyHandlingResponse : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "passport_image")]
		public string PassportImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkin_booking_date")]
		public string CheckinBookingDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkout_booking_date")]
		public string CheckoutBookingDate { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_image")]
		public string UserImage { get; set; }

		private bool isChecked = false;
		public bool IsChecked
		{
			get => isChecked;
			set
			{
				isChecked = value;
				OnPropertyChanged("IsChecked");
			}
		}
	}
}
