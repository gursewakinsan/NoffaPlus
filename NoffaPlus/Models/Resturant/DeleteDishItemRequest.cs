namespace NoffaPlus.Models
{
	public class DeleteDishItemRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "available_dish_id")]
		public int AvailableDishId { get; set; }
	}
}
