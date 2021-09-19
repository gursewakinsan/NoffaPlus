namespace NoffaPlus.Models
{
	public class QueueGuestDetailResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_name")]
		public string GuestName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "phone_number")]
		public string PhoneNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "country_id")]
		public int CountryId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "email_id")]
		public string Emailid { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_serviced")]
		public bool IsServiced { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "location_id")]
		public int LocationId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "queue_id")]
		public int QueueId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "total_person")]
		public int TotalPerson { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serving_user_id")]
		public int? ServingUserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "modified_on")]
		public string ModifiedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "position_inline")]
		public int PositionInLine { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_image")]
		public string UserImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "waiting_time")]
		public string WaitingTime { get; set; }
	}
}
