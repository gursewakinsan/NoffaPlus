namespace NoffaPlus.Models
{
	public class GetAvailableRoomsResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_name")]
		public int RoomName { get; set; }
	}
}
