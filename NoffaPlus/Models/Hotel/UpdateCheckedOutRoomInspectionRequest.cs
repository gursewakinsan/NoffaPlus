namespace NoffaPlus.Models
{
	public class UpdateCheckedOutRoomInspectionRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "room_id")]
		public int RoomId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "inspection_result")]
		public int InspectionResult { get; set; }
	}
}
