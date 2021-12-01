namespace NoffaPlus.Models
{
	public class UpdateDishStockRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "available_dish_id")]
		public int AvailableDishId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "in_stock")]
		public int InStock { get; set; }
	}
}
