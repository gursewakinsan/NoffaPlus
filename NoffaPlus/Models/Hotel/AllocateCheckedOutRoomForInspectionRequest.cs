namespace NoffaPlus.Models
{
	public class AllocateCheckedOutRoomForInspectionRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "room_id")]
		public int RoomId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }
	}
}