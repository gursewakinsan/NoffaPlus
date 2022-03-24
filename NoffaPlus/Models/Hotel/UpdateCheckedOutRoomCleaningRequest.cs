namespace NoffaPlus.Models
{
	public class UpdateCheckedOutRoomCleaningRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "room_id")]
		public int RoomId { get; set; }
	}
}
