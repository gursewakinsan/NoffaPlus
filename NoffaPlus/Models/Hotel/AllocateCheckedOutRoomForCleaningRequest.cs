namespace NoffaPlus.Models
{
	public class AllocateCheckedOutRoomForCleaningRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "room_id")]
		public int RoomId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }
	}
}
