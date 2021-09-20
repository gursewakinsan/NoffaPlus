namespace NoffaPlus.Models
{
	public class OperatorQueueListResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "guest_name")]
		public string GuestName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "total_person")]
		public int TotalPerson { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "waiting_count")]
		public int WaitingCount { get; set; }
		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(GuestName, 0);
	}
}
